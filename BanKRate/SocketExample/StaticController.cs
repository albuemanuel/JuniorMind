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

        public StaticController()
            : this(new DiskRepository())
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
