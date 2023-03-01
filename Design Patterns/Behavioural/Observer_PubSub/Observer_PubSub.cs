#nullable disable warnings

namespace DesignPatterns.Observer_PubSub;

public class Observer_PubSub {
    
    internal abstract class YoutubeSubscriber {
        public abstract void SendNotification(string channel, string message);
    }

    internal class YoutubeUser : YoutubeSubscriber {
        string Name { get; set; }
        
        public YoutubeUser(string name) {
            Name = name;
        }
        
        public override void SendNotification(string channel, string message) {
            Console.WriteLine($"User {Name} received notification from {channel}: {message}");
        }
    }

    internal class YoutubeChannel {
        string Name { get; set; }
        IList<YoutubeUser> Subscribers { get; set; }
        
        public YoutubeChannel(string name) {
            Name = name;
            Subscribers = new List<YoutubeUser>();
        }
        
        public void Subscribe(YoutubeUser sub) {
            Subscribers.Add(sub);
        }
        
        public void Notify(string message) {
            foreach (var sub in Subscribers) {
                sub.SendNotification(Name, message);
            }
        }
    }
    
    public static void Run() {
        var channel = new YoutubeChannel("Bogdan");
        channel.Subscribe(new YoutubeUser("user1"));
        channel.Subscribe(new YoutubeUser("user2"));
        channel.Subscribe(new YoutubeUser("user3"));
        channel.Subscribe(new YoutubeUser("user4"));

        channel.Notify("A new video published");
    }
}
