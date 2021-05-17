using LAb7.Contexts;

namespace LAb7
{
    class Program
    {
        static void Main(string[] args)
        {
            MongoContext mongoContext = new MongoContext();
            mongoContext.Convert();

            RedisContext redisContext = new RedisContext();
            redisContext.Convert();
        }
    }
}
