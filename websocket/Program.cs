using System.Net.WebSockets;
using System.Text;



class Program{
    static async Task Main(){
Uri Uri = new Uri("ws://echo.websocket.org");
ClientWebSocket Kalle = new ClientWebSocket();

await Kalle.ConnectAsync(Uri, default);

string mail = "goblins gillar guld";
byte[] emsg = Encoding.UTF8.GetBytes(mail);
ArraySegment<byte> smsg = new(emsg);
await Kalle.SendAsync(smsg, WebSocketMessageType.Text, true, CancellationToken.None);
byte[] resultat = new byte[1024];
var bres = await Kalle.ReceiveAsync(new ArraySegment<byte>(resultat),CancellationToken.None);
string mottaget = Encoding.UTF8.GetString(resultat,0,bres.Count);
Console.WriteLine(mottaget);
    }
}

