# CLI-Simple-2FA-Authenticator
A simple time-based one-time password authenticator written with C#.

TOTP specified in [RFC 6238](https://datatracker.ietf.org/doc/html/rfc6238/)

### Dependencies:
- [OTP.Net](https://github.com/kspearrin/Otp.NET)

## Features
- A real-time 30 second timer via epoch (unix) time.
- Prints new 6 digit OTP every 30 seconds.
