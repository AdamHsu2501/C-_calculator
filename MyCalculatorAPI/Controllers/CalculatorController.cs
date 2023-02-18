using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;

namespace MyCalculatorAPI.Controllers
{
    /// <summary>
    /// Calculator Controller of ApiController
    /// </summary>
    public partial class CalculatorController : ApiController
    {
        /// <summary>
        /// Cookie id
        /// </summary>
        private const string CookieId = "session-id";

        /// <summary>
        /// 1.Get cookie of Request
        /// 2.Check cookie is valid
        /// 3.return calculator
        /// 4.create new calculator if cookie invalid 
        /// 5.Create cookie and new calculator if no cookie
        /// </summary>
        /// <param name="action">Calculator action</param>
        /// <returns>IHttpActionResult</returns>
        [NonAction]
        public IHttpActionResult DoAction(Action<CalculatorContext> action)
        {
            CookieHeaderValue cookie = Request.Headers.GetCookies(CookieId).FirstOrDefault();

            if (cookie != null)
            {
                var id = cookie[CookieId].Value;
                var cal = CalculatorManager.GetOrCreate(id);
                action(cal);

                return Ok(cal.GetResult());
            }
            else
            {
                string id = CalculatorManager.CreateId();
                var cal = CalculatorManager.Create(id);
                action(cal);

                var response = Request.CreateResponse(System.Net.HttpStatusCode.OK, cal.GetResult());
                cookie = new CookieHeaderValue(CookieId, id);
                cookie.Expires = DateTimeOffset.Now.AddDays(1);
                cookie.Domain = Request.RequestUri.Host;
                cookie.Path = "/";

                response.Headers.AddCookies(new CookieHeaderValue[] { cookie });
                
                return ResponseMessage(response);
            }
        }

        /// <summary>
        /// Handle clear
        /// </summary>
        /// <returns>IHttpActionResult</returns>
        [HttpGet]
        public IHttpActionResult Clear()
        {
            return DoAction(cal => cal.HandleClear());
        }

        /// <summary>
        /// Handle equal
        /// </summary>
        /// <returns>IHttpActionResult</returns>
        [HttpGet]
        public IHttpActionResult Equal()
        {
            return DoAction(cal => cal.HandleEqual());
        }

        /// <summary>
        /// Handle addition
        /// </summary>
        /// <returns>IHttpActionResult</returns>
        [HttpGet]
        public IHttpActionResult Addition()
        {
            return DoAction(cal => cal.HandleAddition());
        }

        /// <summary>
        /// Handle subtraction
        /// </summary>
        /// <returns>IHttpActionResult</returns>
        [HttpGet]
        public IHttpActionResult Subtraction()
        {
            return DoAction(cal => cal.HandleSubtraction());
        }

        /// <summary>
        /// Handle multiplication
        /// </summary>
        /// <returns>IHttpActionResult</returns>
        [HttpGet]
        public IHttpActionResult Multiplication()
        {
            return DoAction(cal => cal.HandleMultiplication());
        }

        /// <summary>
        /// Handle division
        /// </summary>
        /// <returns>IHttpActionResult</returns>
        [HttpGet]
        public IHttpActionResult Division()
        {
            return DoAction(cal => cal.HandleDivision());
        }

        /// <summary>
        /// Handle clear entry
        /// </summary>
        /// <returns>IHttpActionResult</returns>
        [HttpGet]
        public IHttpActionResult ClearEntry()
        {
            return DoAction(cal => cal.HandleClearEntry());
        }

        /// <summary>
        /// Handle number 0
        /// </summary>
        /// <returns>IHttpActionResult</returns>
        [HttpGet]
        public IHttpActionResult Number0()
        {
            return DoAction(cal => cal.HandleNumber("0"));
        }

        /// <summary>
        /// Handle number 1
        /// </summary>
        /// <returns>IHttpActionResult</returns>
        [HttpGet]
        public IHttpActionResult Number1()
        {
            return DoAction(cal => cal.HandleNumber("1"));
        }

        /// <summary>
        /// Handle number 2
        /// </summary>
        /// <returns>IHttpActionResult</returns>
        [HttpGet]
        public IHttpActionResult Number2()
        {
            return DoAction(cal => cal.HandleNumber("2"));
        }

        /// <summary>
        /// Handle number 3
        /// </summary>
        /// <returns>IHttpActionResult</returns>
        [HttpGet]
        public IHttpActionResult Number3()
        {
            return DoAction(cal => cal.HandleNumber("3"));
        }

        /// <summary>
        /// Handle number 4
        /// </summary>
        /// <returns>IHttpActionResult</returns>
        [HttpGet]
        public IHttpActionResult Number4()
        {
            return DoAction(cal => cal.HandleNumber("4"));
        }

        /// <summary>
        /// Handle number 5
        /// </summary>
        /// <returns>IHttpActionResult</returns>
        [HttpGet]
        public IHttpActionResult Number5()
        {
            return DoAction(cal => cal.HandleNumber("5"));
        }

        /// <summary>
        /// Handle number 6
        /// </summary>
        /// <returns>IHttpActionResult</returns>
        [HttpGet]
        public IHttpActionResult Number6()
        {
            return DoAction(cal => cal.HandleNumber("6"));
        }

        /// <summary>
        /// Handle number 7
        /// </summary>
        /// <returns>IHttpActionResult</returns>
        [HttpGet]
        public IHttpActionResult Number7()
        {
            return DoAction(cal => cal.HandleNumber("7"));
        }

        /// <summary>
        /// Handle number 8
        /// </summary>
        /// <returns>IHttpActionResult</returns>
        [HttpGet]
        public IHttpActionResult Number8()
        {
            return DoAction(cal => cal.HandleNumber("8"));
        }

        /// <summary>
        /// Handle number 9
        /// </summary>
        /// <returns>IHttpActionResult</returns>
        [HttpGet]
        public IHttpActionResult Number9()
        {
            return DoAction(cal => cal.HandleNumber("9"));
        }

        /// <summary>
        /// Handle decimal point
        /// </summary>
        /// <returns>IHttpActionResult</returns>
        [HttpGet]
        public IHttpActionResult DecimalPoint()
        {
            return DoAction(cal => cal.HandleDecimalPoint());
        }

        /// <summary>
        /// Handle backspace
        /// </summary>
        /// <returns>IHttpActionResult</returns>
        [HttpGet]
        public IHttpActionResult Backspace()
        {
            return DoAction(cal => cal.HandleBackspace());
        }

        /// <summary>
        /// Handle negate
        /// </summary>
        /// <returns>IHttpActionResult</returns>
        [HttpGet]
        public IHttpActionResult Negate()
        {
            return DoAction(cal => cal.HandleNegate());
        }

        /// <summary>
        /// Handle square root
        /// </summary>
        /// <returns>IHttpActionResult</returns>
        [HttpGet]
        public IHttpActionResult SquareRoot()
        {
            return DoAction(cal => cal.HandleSquareRoot());
        }

        /// <summary>
        /// Handle left parenthesis
        /// </summary>
        /// <returns>IHttpActionResult</returns>
        [HttpGet]
        public IHttpActionResult LeftParenthesis()
        {
            return DoAction(cal => cal.HandleLeftParenthesis());
        }

        /// <summary>
        /// Handle right parenthesis
        /// </summary>
        /// <returns>IHttpActionResult</returns>
        [HttpGet]
        public IHttpActionResult RightParenthesis()
        {
            return DoAction(cal => cal.HandleRightParenthesis());
        }
    }
}
