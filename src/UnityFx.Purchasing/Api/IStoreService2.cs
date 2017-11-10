﻿// Copyright (c) Alexander Bogarsukov.
// Licensed under the MIT license. See the LICENSE.md file in the project root for more information.

using System;
using System.Diagnostics;
using System.Threading.Tasks;
using UnityEngine.Purchasing;

namespace UnityFx.Purchasing
{
	/// <summary>
	/// A generic platform store.
	/// </summary>
	public interface IStoreService2 : IDisposable
	{
		/// <summary>
		/// Triggered when the store has been initialized.
		/// </summary>
		event EventHandler StoreInitialized;

		/// <summary>
		/// Triggered when the store initializzation has failed.
		/// </summary>
		event EventHandler<PurchaseInitializationFailed> StoreInitializationFailed;

		/// <summary>
		/// Triggered when a new purchase is initiated.
		/// </summary>
		event EventHandler<PurchaseInitiatedEventArgs> PurchaseInitiated;

		/// <summary>
		/// Triggered when a purchase has completed successfully.
		/// </summary>
		event EventHandler<PurchaseCompletedEventArgs> PurchaseCompleted;

		/// <summary>
		/// Triggered when a purchase has failed.
		/// </summary>
		event EventHandler<PurchaseFailedEventArgs> PurchaseFailed;

		/// <summary>
		/// Returns the <see cref="SourceSwitch"/> instance attached to the <see cref="TraceSource"/> used by the store. Read only.
		/// </summary>
		SourceSwitch TraceSwitch { get; }

		/// <summary>
		/// Returns a collection of <see cref="TraceListener"/> instances attached to the <see cref="TraceSource"/> used by the store. Read only.
		/// </summary>
		TraceListenerCollection TraceListeners { get; }

		/// <summary>
		/// Returns push notification provider of the store transactions. Read only.
		/// </summary>
		IObservable<PurchaseInfo> Purchases { get; }

		/// <summary>
		/// Returns a collection of store items. Read only.
		/// </summary>
		IStoreProductCollection2 Products { get; }

		/// <summary>
		/// Returns Unity3d store controller. Read only.
		/// </summary>
		IStoreController Controller { get; }

		/// <summary>
		/// Returns <c>true</c> if the store is initialized (the product list is loaded from native store); <c>false</c> otherwise. Read only.
		/// </summary>
		bool IsInitialized { get; }

		/// <summary>
		/// Returns <c>true</c> if the store has pending purchase operation; <c>false</c> otherwise. Read only.
		/// </summary>
		bool IsBusy { get; }

		/// <summary>
		/// Initializes the store (if not initialized already).
		/// </summary>
		/// <exception cref="StoreInitializeException">Thrown if store initialization fails.</exception>
		/// <exception cref="ObjectDisposedException">Thrown if the store instance is disposed.</exception>
		Task InitializeAsync();

		/// <summary>
		/// Fetches product information from the store.
		/// </summary>
		/// <exception cref="StoreInitializeException">Thrown if operation fails.</exception>
		/// <exception cref="ObjectDisposedException">Thrown if the store instance is disposed.</exception>
		Task FetchAsync();

		/// <summary>
		/// Initiates purchasing a product.
		/// </summary>
		/// <param name="productId">Product identifier as specified in the store.</param>
		/// <exception cref="StorePurchaseException">Thrown if an purchase-related errors.</exception>
		/// <exception cref="InvalidOperationException">Thrown if the store state does not allow purchases.</exception>
		/// <exception cref="ArgumentException">Thrown if the <paramref name="productId"/> is invalid.</exception>
		/// <exception cref="ObjectDisposedException">Thrown if the store instance is disposed.</exception>
		Task<PurchaseResult> PurchaseAsync(string productId);
	}
}