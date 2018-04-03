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
        public Response GenerateResponse(Request request)
        {
            Response response = new Response(200);

            if (request.Method == Method.GET)
            {
                byte[] file = null;
                DiskRepository diskRepository = new DiskRepository();
                try
                {
                    file = diskRepository.GetData(request.Uri);
                }

                catch(FileNotFoundException e)
                {
                    response.Payload = Encoding.ASCII.GetBytes(e.ToString());
                    response.SetContentLength(e.ToString().Length);
                    response.SetStatusCode(404);
                }

                response.Payload = file;
            }

            response.AddHeaderField("tralala", "cozonac");

            return response;
        }

        
    }
}
