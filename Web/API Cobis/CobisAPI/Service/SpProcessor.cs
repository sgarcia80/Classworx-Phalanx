using CobisAPI.Model;

namespace CobisAPI.Service
{
    public class SpProcessor
    {
        string spName = "cobis..sp_login";
        public SpResult Process(Model.SpRequest request)
        {
            if (request.SpName != spName)
                throw new Exception("Wrong Sp Name");

            SpParam? login = request.@params.FirstOrDefault(param => param.name.Contains("@i_login"));
            if (login == null)
                throw new Exception("there is no i_login parameter");

            if(login.value.Length > 4)
            {
                SpResult spResult = new SpResult()
                {
                    resultSetListSize = 0,
                    returnCode = 0,
                    errorListSize = 0,
                    resultSets = new List<string>(),
                    dataMessageLoaded = true,
                    messages = new List<Message>(),
                    @params = new List<string>(),
                    errors = new List<string>(),
                    messageListSize = 0
                };
                return spResult;
            }
            else
            {
                Message message = new Message()
                {
                    messageNumber = 1875069,
                    messageText = "[sp_login]  El login no corresponde al cliente seleccionado o no existe",
                    type = 3
                };

                SpResult spResult = new SpResult()
                {
                    resultSetListSize = 0,
                    returnCode = 1875069,
                    errorListSize = 0,
                    resultSets = new List<string>(),
                    dataMessageLoaded = true,
                    messages = new List<Message>() { message },
                    @params = new List<string>(),
                    errors = new List<string>(),
                    messageListSize = 1
                };
                return spResult;
            }
        }

    }
}
