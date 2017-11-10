﻿// Copyright (c) Alexander Bogarsukov.
// Licensed under the MIT license. See the LICENSE.md file in the project root for more information.

using System;
using UnityEngine.Purchasing.Extension;

namespace UnityFx.Purchasing
{
	/// <summary>
	/// Store factory and utility methods.
	/// </summary>
	public static class Store
	{
		/// <summary>
		/// Creates a new <see cref="IStoreService2"/> instance.
		/// </summary>
		/// <exception cref="ArgumentNullException">Thrown if <paramref name="purchasingModule"/> or <paramref name="storeDelegate"/> is <c>null</c>.</exception>
		/// <exception cref="InvalidOperationException">Thrown if an instance of <see cref="IStoreService2"/> already exists.</exception>
		public static IStoreService2 CreateStore(IPurchasingModule purchasingModule, IStoreDelegate storeDelegate)
		{
			if (purchasingModule == null)
			{
				throw new ArgumentNullException(nameof(purchasingModule));
			}

			if (storeDelegate == null)
			{
				throw new ArgumentNullException(nameof(storeDelegate));
			}

			return new StoreService2(string.Empty, purchasingModule, storeDelegate);
		}
	}
}
