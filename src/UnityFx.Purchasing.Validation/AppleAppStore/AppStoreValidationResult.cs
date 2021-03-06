﻿// Copyright (c) Alexander Bogarsukov.
// Licensed under the MIT license. See the LICENSE.md file in the project root for more information.

using System;
using System.Collections;
using System.Collections.Generic;

namespace UnityFx.Purchasing.Validation
{
	/// <summary>
	/// 
	/// </summary>
	public class AppStoreValidationResult : IPurchaseValidationResult
	{
		#region interface

		/// <summary>
		/// Returns App Store response status code. <c>0</c> means OK. Read only.
		/// </summary>
		public int StatusCode { get; internal set; }

		/// <summary>
		/// Returns the store environment identifier. Read only.
		/// </summary>
		public string Environment { get; internal set; }

		/// <summary>
		/// The App Store receipt if any. Read only.
		/// </summary>
		public AppStoreReceipt Receipt { get; internal set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="AppStoreValidationResult"/> class.
		/// </summary>
		internal AppStoreValidationResult(string rawResponse)
		{
			RawResult = rawResponse;
		}

		#endregion

		#region IPurchaseValidationResult

		/// <inheritdoc/>
		public string RawResult { get; }

		/// <inheritdoc/>
		public string Status { get; internal set; }

		/// <inheritdoc/>
		public bool IsOK => StatusCode == 0;

		/// <inheritdoc/>
		public bool IsFailed => StatusCode != 0;

		#endregion

		#region IEnumerable

		/// <inheritdoc/>
		public IEnumerator<IPurchaseReceipt> GetEnumerator()
		{
			return GetEnumeratorInternal();
		}

		/// <inheritdoc/>
		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumeratorInternal();
		}

		#endregion

		#region implementation

		private IEnumerator<IPurchaseReceipt> GetEnumeratorInternal()
		{
			if (Receipt != null && Receipt.InApp != null)
			{
				foreach (var receipt in Receipt.InApp)
				{
					yield return receipt;
				}
			}
		}

		#endregion
	}
}
