﻿// Copyright (c) Alexander Bogarsukov.
// Licensed under the MIT license. See the LICENSE.md file in the project root for more information.

using System;
using UnityEngine.Purchasing;

namespace UnityFx.Purchasing
{
	/// <summary>
	/// Event argument for <see cref="IPlatformStore.PurchaseFailed"/>.
	/// </summary>
	public class PurchaseFailedEventArgs : EventArgs
	{
		/// <summary>
		/// Returns identifier of the target store. Read only.
		/// </summary>
		public string StoreId { get; }

		/// <summary>
		/// Returns the <see cref="UnityEngine.Purchasing.Product"/> reference (if available). Read only.
		/// </summary>
		public Product Product { get; }

		/// <summary>
		/// Returns <c>true</c> if the purchase was auto-restored; <c>false</c> otherwise. Read only.
		/// </summary>
		public bool IsRestored { get; }

		/// <summary>
		/// Returns an error that caused the purchase to fail. Read only.
		/// </summary>
		public StorePurchaseError Error { get; }

		/// <summary>
		/// Initializes a new instance of the <see cref="PurchaseFailedEventArgs"/> class.
		/// </summary>
		public PurchaseFailedEventArgs(string storeId, Product product, PurchaseFailureReason error, bool restored)
		{
			StoreId = storeId;
			Product = product;
			IsRestored = restored;
			Error = StoreService.GetPurchaseError(error);
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="PurchaseFailedEventArgs"/> class.
		/// </summary>
		public PurchaseFailedEventArgs(string storeId, Product product, StorePurchaseError error, bool restored)
		{
			StoreId = storeId;
			Product = product;
			Error = error;
			IsRestored = restored;
		}
	}
}
