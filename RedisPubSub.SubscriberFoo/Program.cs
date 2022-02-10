using StackExchange.Redis;

using var redis = ConnectionMultiplexer.Connect("127.0.0.1:6379");
var sub = redis.GetSubscriber();
var channel = "testChannel";

sub.Subscribe(channel, (channel, message) => {
    Console.WriteLine($"{message}");
});
Console.WriteLine ("subscribed messages comes here");