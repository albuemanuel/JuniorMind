using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JSONParser;
using System.IO;

namespace SocketExample
{
    public class StaticController : IController
    {
        private readonly IRepository repository;

        public StaticController(string baseURI)
            : this(new DiskRepository(baseURI))
        { }

        public StaticController(IRepository repository)
        {
            this.repository = repository;
        }

        public Response GenerateResponse(Request request)
        {
            Response response = new Response(200);

            if (request.Method == Method.GET)
            {
                byte[] file = null;
                try
                {
                    if (repository.IsDirectory(request.Uri))
                    {
                        Uri dirUri = new Uri(request.Uri.ToString() + "/index.htm", UriKind.RelativeOrAbsolute);
                        file = repository.GetData(dirUri);
                    }
                    else
                        file = repository.GetData(request.Uri);

                    response.Payload = file;
                    response.SetContentLength(file.Length);
                }
                catch (DirectoryNotFoundException e)
                {
                    HandleNotFoundException(response, e);
                }
                catch (FileNotFoundException e)
                {
                    HandleNotFoundException(response, e);
                }
            }

            response.AddHeaderField("tralala", "cozonac");
            response.AddHeaderField("Connection", "close");

            return response;
        }

        private static void HandleNotFoundException(Response response, Exception e)
        {
            response.Payload = Encoding.ASCII.GetBytes(e.ToString());
            response.SetContentLength(e.ToString().Length);
            response.SetStatusCode(404);
        }

    }
}
