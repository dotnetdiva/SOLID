using System;

namespace SolidPrinciplesDemo
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine( "===============================================" );
            Console.WriteLine( "     SOLID Principles Demonstration (C#)" );
            Console.WriteLine( "===============================================\n" );

            SingleResponsibility.Demonstrate();
            OpenClosed.Demonstrate();
            LiskovSubstitution.Demonstrate();
            InterfaceSegregation.Demonstrate();
            DependencyInversion.Demonstrate();

            Console.WriteLine( "\n===============================================" );
            Console.WriteLine( " Demonstration complete." );
            Console.WriteLine( "===============================================" );
            Console.ReadKey();
        }
    }

    public static class SingleResponsibility
    {
        public static void Demonstrate()
        {
            Console.WriteLine( "\n[1] Single Responsibility Principle (SRP)" );

            var user = new User { Name = "Alice" };
            var processor = new UserDataProcessor();
            var writer = new FileWriter();

            string data = processor.Process( user );
            writer.SaveToFile( data );
        }

        public class User
        {
            public string Name { get; set; } = "";
        }

        public class UserDataProcessor
        {
            public string Process( User user )
            {
                string result = $"Processed user: {user.Name}";
                Console.WriteLine( result );
                return result;
            }
        }

        public class FileWriter
        {
            public void SaveToFile( string data )
            {
                Console.WriteLine( $"Saving to file: {data}" );
            }
        }
    }

    public static class OpenClosed
    {
        public static void Demonstrate()
        {
            Console.WriteLine( "\n[2] Open/Closed Principle (OCP)" );

            IShape rectangle = new Rectangle { Width = 4, Height = 5 };
            IShape circle = new Circle { Radius = 3 };

            Console.WriteLine( $"Rectangle area: {rectangle.Area()}" );
            Console.WriteLine( $"Circle area: {circle.Area()}" );
        }

        public interface IShape
        {
            double Area();
        }

        public class Rectangle : IShape
        {
            public double Width { get; set; }
            public double Height { get; set; }
            public double Area() => Width * Height;
        }

        public class Circle : IShape
        {
            public double Radius { get; set; }
            public double Area() => Math.PI * Radius * Radius;
        }
    }

    public static class LiskovSubstitution
    {
        public static void Demonstrate()
        {
            Console.WriteLine( "\n[3] Liskov Substitution Principle (LSP)" );

            Bird sparrow = new FlyingBird();
            Bird penguin = new NonFlyingBird();

            sparrow.Move();
            penguin.Move();
        }

        public abstract class Bird
        {
            public abstract void Move();
        }

        public class FlyingBird : Bird
        {
            public override void Move()
            {
                Console.WriteLine( "Flying through the sky..." );
            }
        }

        public class NonFlyingBird : Bird
        {
            public override void Move()
            {
                Console.WriteLine( "Walking on land..." );
            }
        }
    }

    public static class InterfaceSegregation
    {
        public static void Demonstrate()
        {
            Console.WriteLine( "\n[4] Interface Segregation Principle (ISP)" );

            IPrinter printer = new OfficePrinter();
            IScanner scanner = new OfficeScanner();

            printer.Print( "Document: Quarterly Report" );
            scanner.Scan( "Image: Contract Scan" );
        }

        public interface IPrinter
        {
            void Print( string document );
        }

        public interface IScanner
        {
            void Scan( string source );
        }

        public class OfficePrinter : IPrinter
        {
            public void Print( string document )
            {
                Console.WriteLine( $"Printing: {document}" );
            }
        }

        public class OfficeScanner : IScanner
        {
            public void Scan( string source )
            {
                Console.WriteLine( $"Scanning: {source}" );
            }
        }
    }

    public static class DependencyInversion
    {
        public static void Demonstrate()
        {
            Console.WriteLine( "\n[5] Dependency Inversion Principle (DIP)" );

            IMessageService emailService = new EmailService();
            var notification = new Notification( emailService );

            notification.SendAlert( "System update completed successfully." );
        }

        public interface IMessageService
        {
            void Send( string message );
        }

        public class EmailService : IMessageService
        {
            public void Send( string message )
            {
                Console.WriteLine( $"Email sent: {message}" );
            }
        }

        public class Notification
        {
            private readonly IMessageService _service;

            public Notification( IMessageService service )
            {
                _service = service;
            }

            public void SendAlert( string message )
            {
                _service.Send( message );
            }
        }
    }
}
