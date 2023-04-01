using Amazon.Rekognition.Model;
using Amazon.Rekognition;
using Amazon.S3;
using Amazon.S3.Model;
using Microsoft.AspNetCore.Mvc;
using OpenAI_API;
using System.IO;
using OpenAI_API.Completions;
using ChartGptAspReactExamen.Models;
using ChartGptAspReactExamen.Repositories;

namespace ChartGptAspReactExamen.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GptController : Controller
    {   DataRepo dataRepo = new DataRepo();
        static string pathDir = Directory.GetCurrentDirectory() + "/Images/";
        [HttpGet("SendText")]
        public ActionResult SendText(string text,string login="chost")
        {
            OpenAIAPI api = new OpenAIAPI(new APIAuthentication("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", "org-qj8lijI31tVoP5tIORKbLvQl"));
            var result = api.Completions.GetCompletion(text).Result;
            
            //string result="";
            //var openApi = new OpenAIAPI("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");
            //CompletionRequest request = new CompletionRequest();
            //request.Prompt = text;
            //request.Model = OpenAI_API.Models.Model.DavinciText;
            //var completions=openApi.Completions.CreateCompletionAsync(request);
            //foreach (var completion in completions.Result.Completions) { result += completion.Text; }

            dataRepo.AddData(login,DateTime.Now,text,result);
            dataRepo.SetOperationIncrement(login);

            Console.WriteLine(text);
            Console.WriteLine(result);
            return Ok(result);
        }
        [HttpPost("DetectImage")]
        public async Task<ActionResult> DetectImage(IFormFile file)
        {
            if (!TryValidateModel(file, nameof(IFormFile)))
                return BadRequest("Send Another File !");
            ModelState.ClearValidationState(nameof(IFormFile));
            //save file
  
            if (!Directory.Exists(pathDir)) Directory.CreateDirectory(pathDir);
            FileInfo fi = new FileInfo(file.FileName);
            string path="";
            if (file.Length > 0)
            {
                path = dataRepo.RandomName(fi.Extension);
                using (var stream = System.IO.File.Create(path))
                {
                    await file.CopyToAsync(stream);
                   
                }
            }
            ///

            string imageName = file.FileName;
            string bucket = "reml2bucket";
            var putRequest = new PutObjectRequest
            {
                BucketName = bucket,
                Key = imageName,
                FilePath = path,
                ContentType = "text/plain"
            };
            putRequest.Metadata.Add("x-amz-meta-title", "someTitle");
            IAmazonS3 client = new AmazonS3Client("AKIA344VMXIHI53J3UPT", "SmGmMBv4hKZhbIhvDK57ewOnKntKFhK87RDv03L4", Amazon.RegionEndpoint.EUCentral1);
            PutObjectResponse response = client.PutObjectAsync(putRequest).Result;
            // Detect text
            AmazonRekognitionClient rekognitionClient = new AmazonRekognitionClient("AKIA344VMXIHI53J3UPT", "SmGmMBv4hKZhbIhvDK57ewOnKntKFhK87RDv03L4", Amazon.RegionEndpoint.EUCentral1);

            DetectTextRequest detectTextRequest = new DetectTextRequest()
            {
                Image = new Amazon.Rekognition.Model.Image()
                {
                    S3Object = new Amazon.Rekognition.Model.S3Object()
                    { Name = imageName, Bucket = bucket },
                }
            };
            string fullText = "";
            DetectTextResponse detectTextResponse = rekognitionClient.DetectTextAsync(detectTextRequest).Result;
            detectTextResponse.TextDetections.Where(item => item.Type.Value == "WORD").Select(item => item.DetectedText).ToList().ForEach(item => fullText += item + " ");
            //SendText(fullText);
            //Console.WriteLine(fullText);
            return SendText(fullText);
        }






        //public static string RandomName(string extenc)
        //{
        //    while (true)
        //    {
        //        string name = Path.GetRandomFileName();
        //        string fileName = pathDir + name + extenc;
        //        if (!System.IO.File.Exists(fileName))
        //        {
        //            return fileName;
        //        }
        //    }
        //}
    }
}
