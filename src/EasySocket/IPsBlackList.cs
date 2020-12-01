using System;
using System.Collections;
using System.Net;

namespace JadBenAutho.EasySocket
{

	/// <summary>
	/// A collection of IPs black list that the <c>EasyServer</c>
	/// should block connection attempt from their machines.
	/// </summary>
	public class IPsBlackList : CollectionBase, IDisposable
	{

		#region Public functions
		/// <summary>
		/// Adds IP address  to the <c>IPsBlackList</c> collection.
		/// </summary>
		/// <param name="BlackIP">
		/// The IP address for the <c>EasyServer</c> to block.
		/// </param>
		/// <returns>The position into which the new element was inserted.</returns>
		public int Add(string BlackIP)
		{
			return List.Add(BlackIP);
		}

		//-------------------------------------------------------------------------------
		/// <summary>
		/// Inserts an item to the <c>IPsBlackList</c> at the specified position.
		/// </summary>
		/// <param name="Index">
		/// The zero-based index at which value should be inserted.
		/// </param>
		/// <param name="BlackIP">The IPAddress to insert into the IPsBlackList.</param>
		public void Insert(int Index, string BlackIP)
		{
			List.Insert(Index, BlackIP);
		}

		//-------------------------------------------------------------------------------
		/// <summary>
		/// Removes the first occurrence of a specific object from the <c>IPsBlackList</c>.
		/// </summary>
		/// <param name="BlackIP">
		/// The Socket to remove from the <c>IPsBlackList</c>. 
		/// </param>
		public void Remove(string BlackIP)
		{
			List.Remove(BlackIP);
		}

		//-------------------------------------------------------------------------------

		/// <summary>
		/// Removes from the <c>IPsBlackList</c> an item at the specified index.
		/// </summary>
		/// <param name="Index">The zero-based index of the item to remove.
		/// </param>
		public new void RemoveAt(int Index)
		{
			base.RemoveAt(Index);
		}

		//-------------------------------------------------------------------------------

		/// <summary>
		/// Removes all items from the <c>IPsBlackList</c>;
		/// </summary>
		public new void Clear()
		{
			base.Clear();
		}

		/// <summary>
		/// Determines whether two <c>IPsBlackList</c> instances are equal.
		/// </summary>
		/// <param name="BlackList">
		/// <c>IPsBlackList</c> object to compare with the current one.
		/// </param>
		/// <returns>Boolean flag indicates whether the elements are equal.
		/// </returns>
		public bool Equals(IPsBlackList BlackList)
		{
			return (List.Equals(BlackList.List));
		}

		//-------------------------------------------------------------------------------

		/// <summary>
		/// Gets or sets the IP address at the given location.
		/// </summary>
		public string this[int indexer]
		{
			get { return List[indexer].ToString(); }
			set { List[indexer] = value; }
		}

		//-------------------------------------------------------------------------------

		/// <summary>
		/// Determines whether the <c>IPsBlackList</c> contains a specific value.
		/// </summary>
		/// <param name="BlackIP">
		/// The IP address to locate in the <c>IPsBlackList</c>.
		/// </param>
		/// <returns>
		/// True if the string is found in the <c>IPsBlackList</c>; otherwise, false.
		/// </returns>
		public bool Contains(string BlackIP)
		{
			return List.Contains(BlackIP);
		}

		//-------------------------------------------------------------------------------	

		/// <summary>
		/// Determines the index of a specific item in the <c>IPsBlackList</c>.
		/// </summary>
		/// <param name="BlackIP">
		/// The IP address to locate in the <c>IPsBlackList</c>.
		/// </param>
		/// <returns>
		/// The index of value if found in the <c>IPsBlackList</c>; otherwise, -1.
		/// </returns>
		public int IndexOf(string BlackIP)
		{
			return List.IndexOf(BlackIP);
		}

		#endregion

		#region IDisposable Members
		/// <summary>
		/// Releases resources.
		/// </summary>
		public void Dispose()
		{
			List.Clear();
		}

		#endregion
	}
}
