# Unity GraphQL Client

This project is a work in progress and is subject to change.

## Example Usage

```csharp
using UnityEngine;

public class NetworkExample : MonoBehaviour {

  // The URL for our GraphQL server
  public string url = "http://localhost:5000/graphql";

  // The authentication token for our server (optional)
  public string authToken;

  // Our GraphQL client
  GraphQL.Client client;

  void Start () {
    // Create our GraphQL client instance with the URL
    client = new GraphQL.Client(url);

    // Set our authentication token (if any)
    if (authToken != null) {
      client.SetAuthToken(authToken);
    }
  }

  public void GetItem (string itemId) {
    // Prepare the query
    var request = client.PrepareQuery(@"
      query GetItem ($id: String) {
        item (id: $id) { name }
      }
    ");

    // Add variables to the query
    request.AddVariable("id", itemId);

    // Start a coroutine to process our request
    StartCoroutine(request.Send(HandleItemResponse));
  }

  // Typical response handler example
  void HandleItemResponse (WWW www) {
    // do what you will from here
  }

}
```