// See https://aka.ms/new-console-template for more information
using OtpNet;



void Welcome()
{

    Console.WriteLine("A Simple TOTP 2FA Program");
        Console.WriteLine("Github: kntjspr");
      
    

}

//------<// Main >------
bool loop = true;
Welcome();
Console.Write("Enter 2FA Secret: ");
string base32Secret = Console.ReadLine();

byte[] secret; //Init secret for try catch
try
{
      secret = Base32Encoding.ToBytes(base32Secret);
   
}
catch (Exception e)
{
    Console.WriteLine("Invalid 2FA Secret Key!");
    return;
}

var totp = new Totp(secret);
var totpCode = totp.ComputeTotp(DateTime.UtcNow); // Compute OTP Code
System.Console.WriteLine("\rOTP Code is: " + totpCode); //Print OTP Code



int TimeRemaining()
{
    var remainingSeconds = totp.RemainingSeconds();
    return remainingSeconds;
}

Thread.Sleep(1000);

while (loop == true)
{
    Console.Write("\rOTP Expires in: " + TimeRemaining() + " "); //Additional space string just to fix the bug on the timer that prints 90 instead of 9 seconds
  
    Thread.Sleep(1000);

    if (TimeRemaining() == 30) // If the countdown goes back to 30 again then we'll refresh to get the new code
    {
        GC.Collect(); //C# Garbage Collector to free memory.
        Console.Clear();
        Welcome();
        Console.Write("Enter 2FA Secret: " + base32Secret); // Print again the inputted secret key
        totpCode = totp.ComputeTotp(DateTime.UtcNow); // Compute new OTP Code
        System.Console.WriteLine("\nNew OTP Code is: " + totpCode); //Print new OTP Code

    }

}
