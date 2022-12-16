# Our Application


## Our API

### HTTP-Based

"Resource Oriented Architecture"

- Resources
    - Important thingies you want to expose to the users of your API
    - Resources have names. Uniform Resource Identifiers (URI) and they look this:


`https://api.hypertheory.com:1338/policies/co?type=motorcycle`

- `https://` - *Scheme* (either `http://` or `https://`)
    Https is Transport-Layer Security - it is encrypted on the transport layer.
    Requires a combination of symmetric and asymetric encryption using x-509 certificates.

- `api.hypertheory.com` - "server", or "authority"
- `:1338` is the TCP Port. The default for HTTP is port 80, which means if your API is running on port 80 (for http), (443) for https you don't have to specify it.



## HTTP

An "application layer" protocol.

"Application Layer" - how two application can speak.
"Transport Layer" - how those two applications connect or send messages to each other across the internet. 
    - TCP (Transmission Control Protocol)
        - What HTTP Uses.*
        - It is Stateful - a client makes a connection and that connection is maintained for the duration of the conversation.
    - UDP (User Datagram Protocol)


- Http Defines two kinds of "Messages"

- User Agents (the client software)
    - Creates REQUEST messages


```http
GET /people
Server: http://localhost:1337
Accept: application/json

```

- The server (Origin) listens passively for requests and makes RESPONSE messages.

```http
200 Ok
Content-Type: application/json

{
    "people": [
        { "id": "1", "name": "Bob Smith"},
        { "id": "2", "name": "Sue Jones"}
    ]
}
```