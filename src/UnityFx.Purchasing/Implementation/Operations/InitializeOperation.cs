﻿// Copyright (c) Alexander Bogarsukov.
// Licensed under the MIT license. See the LICENSE.md file in the project root for more information.

using System;
using System.Diagnostics;
using UnityEngine.Purchasing;
using UnityEngine.Purchasing.Extension;

namespace UnityFx.Purchasing
{
	/// <summary>
	/// An initialize operation.
	/// </summary>
	internal class InitializeOperation : StoreConfigOperation
	{
		#region data

		private readonly IPurchasingModule _purchasingModule;

		#endregion

		#region interface

		public InitializeOperation(StoreService store, IPurchasingModule purchasingModule, AsyncCallback asyncCallback, object asyncState)
			: base(store, StoreOperationType.Initialize, asyncCallback, asyncState)
		{
			_purchasingModule = purchasingModule;

			Store.OnInitializeInitiated(this);
		}

		#endregion

		#region StoreConfigOperation

		protected override void Initiate(StoreConfig storeConfig)
		{
			var configurationBuilder = ConfigurationBuilder.Instance(_purchasingModule);
			configurationBuilder.AddProducts(storeConfig.Products);
			Store.OnInitialize(configurationBuilder, storeConfig);
		}

		protected override void InvokeCompleted(StoreFetchError reason, Exception e)
		{
			Store.OnInitializeCompleted(this, reason, e);
		}

		#endregion
	}
}
