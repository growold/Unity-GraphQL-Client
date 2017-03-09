using UnityEngine;
using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace GraphQL {
  public class Query {

    Client client;
    string query;
    Dictionary<string, object> variables;
    public delegate void Response (WWW www);

    /**
      * Sets up a new query using the given query string.
      */
    public Query (Client client, string query) {
      this.client = client;
      this.query = query;
      variables = new Dictionary<string, object> ();
    }

    /**
      * Add a variable to the query request.
      */
    public Query AddVariable (string key, object value) {
      variables.Add(key, value);
      return this;
    }

    /**
      * Generates the JSON string for the request body.
      */
    public string GetQueryBody () {
      return JsonUtility.ToJson(new QueryDTO {
        query = query,
        variables = variables
      });
    }

    /**
      * Send the request using IEnumerator.
      */
    public IEnumerator Send (Response onResponse) {
      var data = Encoding.UTF8.GetBytes(GetQueryBody());
      var www  = new WWW(client.Url, data, client.Headers);
      yield return www;
      onResponse(www);
    }

    [Serializable]
    struct QueryDTO {
      public string query;
      public Dictionary<string, object> variables;
    }

  }

}
