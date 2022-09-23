using GraphQLDemo.Models;

namespace GraphQLDemo
{
    public class Query : ObjectType<Book>
    {
        public string Hello() => "World";

        
    }

   
}
