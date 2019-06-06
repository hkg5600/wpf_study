using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeShop
{
    class Talk : ObservableCollection<Message>
    {
        public Talk()
        {
            this.Add(new Message() {Sender="Adventure Works", Content="Hi, what can we do for you?"});
            this.Add(new Message() { Sender = "Client", Content = "Did you receive the GR268 KZ bike?" });
            this.Add(new Message() { Sender = "Adventure Works", Content = "Not yet, but we have a similar model available." });
            this.Add(new Message() { Sender = "Client", Content = "What is it like?" });
        }
    }

    public class Message
    {
        public String Sender { get; set; }
        public string Content { get; set; }
    }

}
