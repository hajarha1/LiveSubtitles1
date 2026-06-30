using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace LiveSubtitles.Controllers
{
    public class SubtitlesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task Stream(CancellationToken ct, int from = 0)
        {
            var response = Response;
            response.Headers["Content-Type"] = "text/event-stream";
            response.Headers["Cache-Control"] = "no-cache";
            response.Headers["X-Accel-Buffering"] = "no";

            var sentences = new[]
            {
        "مرحباً بكم في البث المباشر.",
        "Hello, welcome to the live stream!",
        "هذا مشروع الترجمة الفورية باستخدام SSE.",
        "Bonjour, voilà un exemple de flux en direct.",
        "نحن نستخدم تقنية Server-Sent Events.",
        "This is Advanced Web Development project.",
        "البث المباشر يعمل بشكل ممتاز الآن.",
        "Welcome to the future of web streaming!",
        "تقنية SSE تتيح البث المستمر بسهولة.",
        "Live captions make content more accessible.",
        "الترجمة الفورية تساعد الجميع على الفهم.",
        "Streaming technology is amazing and powerful.",
        "هذا المشروع من جامعة إدلب لتقانات الويب.",
        "Real-time subtitles are the future of media."
    };

            for (int i = from; i < sentences.Length; i++)
            {
                if (ct.IsCancellationRequested) break;

                var json = $"{{\"index\":{i},\"text\":\"{sentences[i]}\"}}";
                await response.WriteAsync($"data: {json}\n\n");
                await response.Body.FlushAsync(ct);
                await Task.Delay(2000, ct);
            }

            // لما تخلص الجمل ابعت إشارة للمتصفح
            await response.WriteAsync("data: {\"index\":-1,\"text\":\"DONE\"}\n\n");
            await response.Body.FlushAsync(ct);
        }




















        //        public async Task Stream(CancellationToken ct, int from = 0)
        //        {
        //            var response = Response;
        //            response.Headers["Content-Type"] = "text/event-stream";
        //            response.Headers["Cache-Control"] = "no-cache";
        //            response.Headers["X-Accel-Buffering"] = "no";

        //            var sentences = new[]
        //   {
        //    "مرحباً بكم في البث المباشر.",
        //    "Hello, welcome to the live stream!",
        //    "هذا مشروع الترجمة الفورية باستخدام SSE.",
        //    "Bonjour, voilà un exemple de flux en direct.",
        //    "نحن نستخدم تقنية Server-Sent Events.",
        //    "This is Advanced Web Development project.",
        //    "البث المباشر يعمل بشكل ممتاز الآن.",
        //    "Welcome to the future of web streaming!",
        //    "تقنية SSE تتيح البث المستمر بسهولة.",
        //    "Live captions make content more accessible.",
        //    "الترجمة الفورية تساعد الجميع على الفهم.",
        //    "Streaming technology is amazing and powerful.",
        //    "هذا المشروع من جامعة إدلب لتقانات الويب.",
        //    "Real-time subtitles are the future of media."
        //};

        //            // ابدأ من آخر جملة وصلت
        //            for (int i = from; i < sentences.Length; i++)
        //            {
        //                if (ct.IsCancellationRequested) break;

        //                var json = $"{{\"index\":{i},\"text\":\"{sentences[i]}\"}}";
        //                await response.WriteAsync($"data: {json}\n\n");
        //                await response.Body.FlushAsync(ct);
        //                await Task.Delay(2000, ct);
        //            }
        //        }





        //public async Task Stream(CancellationToken ct)
        //{
        //    var response = Response;
        //    response.Headers["Content-Type"] = "text/event-stream";
        //    response.Headers["Cache-Control"] = "no-cache";
        //    response.Headers["X-Accel-Buffering"] = "no";

        //    // جمل تجريبية للبث
        //    var sentences = new[]
        //    {
        //        "مرحباً بكم في البث المباشر.",
        //        "هذا مشروع الترجمة الفورية.",
        //        "نحن نستخدم تقنية SSE.",
        //        "Hello, this is a live subtitle stream.",
        //        "Welcome to Advanced Web Development."
        //    };

        //    foreach (var sentence in sentences)
        //    {
        //        if (ct.IsCancellationRequested) break;

        //        var data = $"data: {sentence}\n\n";
        //        await response.WriteAsync(data, Encoding.UTF8, ct);
        //        await response.Body.FlushAsync(ct);
        //        await Task.Delay(2000, ct); // جملة كل ثانيتين
        //    }
        //}
    }
}