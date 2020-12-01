
namespace JadBenAutho.EasySocket
{
	/// <summary>
	/// A collection of <c>EasyClients</c> objects.
	/// </summary>
	public sealed class EasyClientsList : System.Collections.CollectionBase, System.IDisposable
	{
		#region Public functions

		/// <summary>
		/// Adds an client object to the <c>EasyClients</c> collection.
		/// </summary>
		/// <param name="ClientObject"><c>EasyClient</c> object to add to the collection.</param>
		/// <returns>The position into which the new element was inserted.</returns>
		public int Add(EasyClient ClientObject)
		{
			return List.Add(ClientObject);
		}

		/// <summary>
		/// Inserts an item to the <c>EasyClientsList</c> at the specified position.
		/// </summary>
		/// <param name="Index">
		/// The zero-based index at which value should be inserted.
		/// </param>
		/// <param name="ClientObject">
		/// The <c>EasyClient</c> to insert into the <c>>EasyClientsList</c>.
		/// </param>

		public void Insert(int Index, EasyClient ClientObject)
		{
			List.Insert(Index, ClientObject);
		}
		/// <summary>
		/// removes the first occurrence of a specific object from the EasyClientsList.
		/// </summary>
		/// <param name="ClientObject">
		/// The EasyClient to remove from the EasyClientsList. 
		/// </param>
		public void Remove(EasyClient ClientObject)
		{
			List.Remove(ClientObject);
		}

		/// <summary>
		/// Removes the EasyClientsList item at the specified index.
		/// </summary>
		/// <param name="Index">The zero-based index of the item to remove.
		/// </param>
		public new void RemoveAt(int Index)
		{
			base.RemoveAt(Index);
		}


		/// <summary>
		/// Removes all items from the <c>EasyClientsList</c>;
		/// </summary>
		public new void Clear()
		{
			base.Clear();
		}

		/// <summary>
		/// Determines whether two <c>EasyClientsLists</c> instances are equal.
		/// </summary>
		/// <param name="ClientsList">
		/// <c>EasyClientsLists</c> object to compare with the current one.
		/// </param>
		/// <returns>Boolean flag indicates wheather the elements are equal.
		/// </returns>
		public bool Equals(EasyClientsList ClientsList)
		{
			return (List.Equals(ClientsList.List));
		}

		/// <summary>
		/// Gets or sets the <c>EasyClient</c> object at the given location.
		/// </summary>
		public EasyClient this[int indexer]
		{
			get { return (EasyClient)List[indexer]; }
			set { List[indexer] = value; }
		}

		/// <summary>
		/// Determines whether the <c>EasyClientsList</c> contains a specific value.
		/// </summary>
		/// <param name="ClientObject">
		/// The <c>EasyClient</c> object to locate in the <c>EasyClientsList</c>.
		/// </param>
		/// <returns>
		/// True if the <c>EasyClient</c> is found in the <c>EasyClientsList</c>;
		/// otherwise, false.
		/// </returns>
		public bool Contains(EasyClient ClientObject)
		{
			return List.Contains(ClientObject);
		}

		/// <summary>
		/// Determines the index of a specific item in the <c>EasyClientsList</c>.
		/// </summary>
		/// <param name="ClientObject">
		/// The <c>EasyClient</c> to locate in the <c>EasyClientsList</c>.
		/// </param>
		/// <returns>
		/// The index of value if found in the <c>EasyClientsList</c>; otherwise, -1.
		/// </returns>
		public int IndexOf(EasyClient ClientObject)
		{
			return List.IndexOf(ClientObject);
		}

		#endregion

		#region IDisposable Members

		/// <summary>
		/// Releases resources
		/// </summary>
		public void Dispose()
		{
			foreach (EasyClient EZclient in List) {
				EZclient.Dispose();
			}
			List.Clear();
		}

		#endregion
	}
}
