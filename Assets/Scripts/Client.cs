using System;
using System.Collections.Generic;

namespace GraphQL {
	public class Client {

		public readonly string Url;
		public readonly Dictionary<string, string> Headers;

		/**
		 * Create a new GraphQL client for generating requests.
		 */
		public Client (string url) {
			Url = url;
			Headers = new Dictionary<string, string>();
			Headers.Add("Content-Type", "application/json");
			Headers.Add("Accept", "application/json");
		}

		/**
		 * Set the authentication token used by the Authorization header
		 * for the request.
		 */
		public void SetAuthToken (string token) {
			Headers.Add("Authorization", token);
		}

		/**
		 * Run a query against the server and capture the result in a "promise".
		 */
		public Query PrepareQuery (string query) {
			return new Query(this, query);
		}

	}
}