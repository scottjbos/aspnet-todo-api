using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using TodoApi.Attributes;

namespace TodoApi.Controllers
{
    /// <inheritdoc />
    /// <summary>
    /// A secret controller that should not exposed to the public API help page.
    /// </summary>
    [ApiExplorerSettings(IgnoreApi = true)]
    [Route("api/secret")]
    public class SecretController: ApiController
    {
        /// <summary>
        /// Gets the Todo applications secrets.
        /// </summary>
        /// <returns>Returns all the secrets</returns>
        [HttpGet]
        [ResponseCodes(HttpStatusCode.OK)]
        [ResponseType(typeof(string))]
        public IHttpActionResult GetSecretCode()
        {
            return Ok("secret code");
        }
    }
}