# CLI-Simple-2FA-Authenticator
A simple time-based one-time password authenticator on CLI.

TOTP specified in [RFC 6238](https://datatracker.ietf.org/doc/html/rfc6238/)

It uses [OTP.Net](https://github.com/kspearrin/Otp.NET) library.

## Features
- A real-time 30 second timer by converting epoch time.
- Prints new 6 digit OTP every 30 seconds.
