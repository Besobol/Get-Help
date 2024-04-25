using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Get_Help.Infrastructure.Data.Models.Seed
{
    public class SeedDb
    {
        public AgentRole AgentRole { get; set; }
        public ClientRole ClientRole { get; set; }
        public Agent AgentUser { get; set; }
        public Client ClientUser { get; set; }
        public List<Service> Services { get; set; } = new();
        public List<Topic> Topics { get; set; } = new();
        public List<Ticket> Tickets { get; set; } = new();
        public List<Message> Messages { get; set; } = new();

        public SeedDb()
        {
            SeedRoles();
            SeedUsers();
            SeedServices();
            SeedTopics();
            SeedTickets();
            SeedMessages();
        }

        private void SeedRoles()
        {
            AgentRole = new AgentRole()
            {
                Id = 1,
                Name = "Agent",
                NormalizedName = "AGENT",
            };

            ClientRole = new ClientRole()
            {
                Id = 2,
                Name = "Client",
                NormalizedName = "CLIENT"
            };
        }

        private void SeedUsers()
        {
            var agentHasher = new PasswordHasher<Agent>();
            var clientHasher = new PasswordHasher<Client>();

            AgentUser = new Agent()
            {
                Id = 2,
                UserName = "Smith@agent.com",
                Email = "Smith@agent.com",
                NormalizedUserName = "SMITH@AGENT.COM",
                NormalizedEmail = "SMITH@AGENT.COM",
                Name = "Agent Smith",
                SecurityStamp = Guid.NewGuid().ToString(),
            };

            ClientUser = new Client()
            {
                Id = 3,
                UserName = "JDoe",
                Email = "JDoe@user.com",
                NormalizedUserName = "JDOE",
                NormalizedEmail = "JDOE@USER.COM",
                SecurityStamp = Guid.NewGuid().ToString(),
            };

            AgentUser.PasswordHash = agentHasher.HashPassword(AgentUser, "MatrixRules");
            ClientUser.PasswordHash = clientHasher.HashPassword(ClientUser, "INeedAnswers");
        }

        private void SeedServices()
        {
            Services.AddRange(
                [
                    new Service()
                    {
                        Id= 1,
                        ImgUrl = "https://nepirockcastle.com/wp-content/uploads/2019/03/Technopolis-bg-logo.png",
                        Name = "Technopolis"
                    },
                    new Service()
                    {
                        Id= 2,
                        ImgUrl = "https://th.bing.com/th/id/OIP.kxBLq5pbWza-QlJHrOyz6QHaDt?rs=1&pid=ImgDetMain",
                        Name = "Technomarket"
                    },
                    new Service()
                    {
                        Id= 3,
                        ImgUrl = "Images/ServiceImages/Amazon.jpg",
                        Name = "Amazon"
                    },
                    new Service()
                    {
                        Id= 4,
                        ImgUrl = "Images/ServiceImages/eBay.png",
                        Name = "eBay"
                    }
                ]);
        }

        private void SeedTopics()
        {
            Topics.AddRange(
                [
                    new Topic()
                    {
                        Id = 1,
                        Name = "How to cancel my purchase?",
                        ServiceId = 1
                    },
                    new Topic()
                    {
                        Id = 2,
                        Name = "Account problems",
                        ServiceId = 1
                    },
                    new Topic()
                    {
                        Id = 3,
                        Name = "Payment plans",
                        ServiceId = 1
                    },
                    new Topic()
                    {
                        Id = 4,
                        Name = "Technical advice",
                        ServiceId = 1
                    },
                ]);
        }

        private void SeedTickets()
        {
            Tickets.AddRange(
                [
                    new Ticket()
                    {
                        Id = 1,
                        Title = "What are good PC parts at the moment",
                        ClientId = 3,
                        TopicId = 4,
                        TimeOpened = DateTime.Now.AddDays(-5),
                    },
                    new Ticket()
                    {
                        Id = 2,
                        Title = "How to find a good fridge",
                        ClientId = 3,
                        TopicId = 4,
                        TimeOpened = DateTime.Now.AddDays(-100),
                    },
                    new Ticket()
                    {
                        Id = 3,
                        Title = "Can i use this microwave as an oven",
                        ClientId = 3,
                        TopicId = 4,
                        TimeOpened = DateTime.Now.AddDays(-20),
                    },
                    new Ticket()
                    {
                        Id = 4,
                        Title = "What are good deals at the moment",
                        ClientId = 3,
                        TopicId = 4,
                        TimeOpened = DateTime.Now.AddDays(-15),
                    },
                    new Ticket()
                    {
                        Id = 5,
                        Title = "What are good deals at the moment",
                        ClientId = 3,
                        TopicId = 4,
                        TimeOpened = DateTime.Now.AddDays(-15),
                    },
                    new Ticket()
                    {
                        Id = 6,
                        Title = "What are good deals at the moment",
                        ClientId = 3,
                        TopicId = 4,
                        TimeOpened = DateTime.Now.AddDays(-15),
                    },
                    new Ticket()
                    {
                        Id = 7,
                        Title = "What are good deals at the moment",
                        ClientId = 3,
                        TopicId = 4,
                        TimeOpened = DateTime.Now.AddDays(-15),
                    },
                    new Ticket()
                    {
                        Id = 8,
                        Title = "What are good deals at the moment",
                        ClientId = 3,
                        TopicId = 4,
                        TimeOpened = DateTime.Now.AddDays(-15),
                    },
                    new Ticket()
                    {
                        Id = 9,
                        Title = "What are good deals at the moment",
                        ClientId = 3,
                        TopicId = 4,
                        TimeOpened = DateTime.Now.AddDays(-15),
                    },
                    new Ticket()
                    {
                        Id = 10,
                        Title = "What are good deals at the moment",
                        ClientId = 3,
                        TopicId = 4,
                        TimeOpened = DateTime.Now.AddDays(-15),
                    },
                    new Ticket()
                    {
                        Id = 11,
                        Title = "What are good deals at the moment",
                        ClientId = 3,
                        TopicId = 4,
                        TimeOpened = DateTime.Now.AddDays(-15),
                    },
                    new Ticket()
                    {
                        Id = 12,
                        Title = "What are good deals at the moment",
                        ClientId = 3,
                        TopicId = 4,
                        TimeOpened = DateTime.Now.AddDays(-15),
                    },
                    new Ticket()
                    {
                        Id = 13,
                        Title = "What are good deals at the moment",
                        ClientId = 3,
                        TopicId = 4,
                        TimeOpened = DateTime.Now.AddDays(-15),
                    },
                    new Ticket()
                    {
                        Id = 14,
                        Title = "What are good deals at the moment",
                        ClientId = 3,
                        TopicId = 4,
                        TimeOpened = DateTime.Now.AddDays(-15),
                    },
                    new Ticket()
                    {
                        Id = 15,
                        Title = "What are good deals at the moment",
                        ClientId = 3,
                        TopicId = 4,
                        TimeOpened = DateTime.Now.AddDays(-15),
                    },
                    new Ticket()
                    {
                        Id = 16,
                        Title = "What are good deals at the moment",
                        ClientId = 3,
                        TopicId = 4,
                        TimeOpened = DateTime.Now.AddDays(-15),
                    },
                    new Ticket()
                    {
                        Id = 17,
                        Title = "What are good deals at the moment",
                        ClientId = 3,
                        TopicId = 4,
                        TimeOpened = DateTime.Now.AddDays(-15),
                    },
                    new Ticket()
                    {
                        Id = 18,
                        Title = "What are good deals at the moment",
                        ClientId = 3,
                        TopicId = 4,
                        TimeOpened = DateTime.Now.AddDays(-15),
                    },
                    new Ticket()
                    {
                        Id = 19,
                        Title = "What are good deals at the moment",
                        ClientId = 3,
                        TopicId = 4,
                        TimeOpened = DateTime.Now.AddDays(-15),
                    },
                    new Ticket()
                    {
                        Id = 20,
                        Title = "What are good deals at the moment",
                        ClientId = 3,
                        TopicId = 4,
                        TimeOpened = DateTime.Now.AddDays(-15),
                    },
                    new Ticket()
                    {
                        Id = 21,
                        Title = "What are good deals at the moment",
                        ClientId = 3,
                        TopicId = 4,
                        TimeOpened = DateTime.Now.AddDays(-15),
                    },
                    new Ticket()
                    {
                        Id = 22,
                        Title = "What are good deals at the moment",
                        ClientId = 3,
                        TopicId = 4,
                        TimeOpened = DateTime.Now.AddDays(-15),
                    },
                    new Ticket()
                    {
                        Id = 23,
                        Title = "What are good deals at the moment",
                        ClientId = 3,
                        TopicId = 4,
                        TimeOpened = DateTime.Now.AddDays(-15),
                    },
                    new Ticket()
                    {
                        Id = 24,
                        Title = "What are good deals at the moment",
                        ClientId = 3,
                        TopicId = 4,
                        TimeOpened = DateTime.Now.AddDays(-15),
                    },
                    new Ticket()
                    {
                        Id = 25,
                        Title = "What are good deals at the moment",
                        ClientId = 3,
                        TopicId = 4,
                        TimeOpened = DateTime.Now.AddDays(-15),
                    },
                    new Ticket()
                    {
                        Id = 26,
                        Title = "What are good deals at the moment",
                        ClientId = 3,
                        TopicId = 4,
                        TimeOpened = DateTime.Now.AddDays(-15),
                    },
                    new Ticket()
                    {
                        Id = 27,
                        Title = "What are good deals at the moment",
                        ClientId = 3,
                        TopicId = 4,
                        TimeOpened = DateTime.Now.AddDays(-15),
                    },
                    new Ticket()
                    {
                        Id = 28,
                        Title = "What are good deals at the moment",
                        ClientId = 3,
                        TopicId = 4,
                        TimeOpened = DateTime.Now.AddDays(-15),
                    },
                    new Ticket()
                    {
                        Id = 29,
                        Title = "What are good deals at the moment",
                        ClientId = 3,
                        TopicId = 4,
                        TimeOpened = DateTime.Now.AddDays(-15),
                    },
                    new Ticket()
                    {
                        Id = 30,
                        Title = "What are good deals at the moment",
                        ClientId = 3,
                        TopicId = 4,
                        TimeOpened = DateTime.Now.AddDays(-15),
                    },
                    new Ticket()
                    {
                        Id = 31,
                        Title = "What are good deals at the moment",
                        ClientId = 3,
                        TopicId = 4,
                        TimeOpened = DateTime.Now.AddDays(-15),
                    }
                ]);
        }

        private void SeedMessages()
        {
            Messages.AddRange(
                [
                    new Message(){
                        Id = 1,
                        Content = "I need advice about my question",
                        SentTime = DateTime.Now,
                        TicketId = 1,
                        ClientId = 3,
                    },
                    new Message(){
                        Id = 2,
                        Content = "Answer",
                        SentTime = DateTime.Now,
                        TicketId = 1,
                        AgentId = 2,
                    },
                    new Message(){
                        Id = 3,
                        Content = "Question",
                        SentTime = DateTime.Now,
                        TicketId = 1,
                        ClientId = 3,
                    },
                    new Message(){
                        Id = 4,
                        Content = "Confusion?",
                        SentTime = DateTime.Now,
                        TicketId = 1,
                        AgentId = 2,
                    },
                    new Message(){
                        Id = 5,
                        Content = "Paragraph of explanation: The morning sun gently kissed the dewy grass as birds chirped melodies of a new day. Amidst the tranquility, whispers of adventure beckoned, enticing souls to explore the unknown. With each step, the world unfolded, revealing secrets waiting to be discovered.\r\nThe world hummed with the rhythm of life, where each heartbeat echoed a tale untold. Beneath the azure sky, dreams danced like leaves in the wind, weaving stories of hope and resilience. In the symphony of existence, every moment held the promise of infinite possibilities, waiting to be embraced.",
                        SentTime = DateTime.Now,
                        TicketId = 1,
                        ClientId = 3,
                    },
                ]);
        }

    }
}
