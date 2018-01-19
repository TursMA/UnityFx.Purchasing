﻿// Copyright (c) Alexander Bogarsukov.
// Licensed under the MIT license. See the LICENSE.md file in the project root for more information.

using System;
using UnityEngine.Purchasing;

namespace UnityFx.Purchasing
{
	/// <summary>
	/// A store purchase result for failed purchases.
	/// </summary>
	[Serializable]
	public class FailedPurchaseResult : PurchaseResult
	{
		#region data

		private StorePurchaseError _error;
		private Exception _exception;

		#endregion

		#region interface

		/// <summary>
		/// Returns an error that caused the purchase to fail. Read only.
		/// </summary>
		public StorePurchaseError Reason => _error;

		/// <summary>
		/// Returns exception that caused the failure (if any). Read only.
		/// </summary>
		public Exception Exception => _exception;

		/// <summary>
		/// Returns <see langword="true"/> if the purchase operation has failed; <see langword="false"/> otherwise. Read only.
		/// </summary>
		public bool IsCanceled => _error == StorePurchaseError.UserCanceled;

		/// <summary>
		/// Initializes a new instance of the <see cref="FailedPurchaseResult"/> class.
		/// </summary>
		public FailedPurchaseResult(string productId, Product product, StorePurchaseError error, Exception e, bool restored)
			: base(productId, product, restored)
		{
			_error = error;
			_exception = e;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="FailedPurchaseResult"/> class.
		/// </summary>
		public FailedPurchaseResult(string productId, PurchaseResult purchaseResult, StorePurchaseError error, Exception e, bool restored)
			: base(productId, purchaseResult.TransactionInfo, purchaseResult.ValidationResult, restored)
		{
			_error = error;
			_exception = e;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="FailedPurchaseResult"/> class.
		/// </summary>
		public FailedPurchaseResult(string productId, StoreTransaction transactionInfo, PurchaseValidationResult validationResult, StorePurchaseError error, Exception e, bool restored)
			: base(productId, transactionInfo, validationResult, restored)
		{
			_error = error;
			_exception = e;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="FailedPurchaseResult"/> class.
		/// </summary>
		public FailedPurchaseResult(StorePurchaseException e)
			: base(e.ProductId, e.Result.TransactionInfo, e.Result.ValidationResult, e.Result.IsRestored)
		{
			_error = e.Reason;
			_exception = e;
		}

		#endregion
	}
}
