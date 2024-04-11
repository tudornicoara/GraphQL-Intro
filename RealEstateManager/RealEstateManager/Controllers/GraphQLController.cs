using Microsoft.AspNetCore.Mvc;
using RealEstateManager.Utilities;
using GraphQL;
using GraphQL.NewtonsoftJson;
using GraphQL.Types;

namespace RealEstateManager.Controllers;

[Route("[controller]")]
public class GraphQLController : Controller
{
    private readonly ISchema _schema;
    private readonly IDocumentExecuter _documentExecuter;

    public GraphQLController(ISchema schema, IDocumentExecuter documentExecuter)
    {
        _schema = schema;
        _documentExecuter = documentExecuter;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] GraphQLQuery query)
    {
        if (query == null)
        {
            throw new ArgumentNullException(nameof(query));
        }

        // var input = query.Variables?.ToInputs();
        var inputs = new GraphQLSerializer().Deserialize<Inputs>(query.Variables);
        var executionOptions = new ExecutionOptions
        {
            Schema = _schema,
            Query = query.Query,
            Variables = inputs
        };

        var result = await _documentExecuter
            .ExecuteAsync(executionOptions);

        if (result.Errors.Any())
        {
            return BadRequest(result);
        }

        return Ok(result);
    }
}