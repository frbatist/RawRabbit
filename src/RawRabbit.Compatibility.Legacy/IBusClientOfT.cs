﻿using System;
using System.Threading.Tasks;
using RawRabbit.Common;
using RawRabbit.Configuration.Publish;
using RawRabbit.Configuration.Request;
using RawRabbit.Configuration.Respond;
using RawRabbit.Configuration.Subscribe;
using RawRabbit.Context;

namespace RawRabbit.Compatibility.Legacy
{
	public interface IBusClient<out TMessageContext> where TMessageContext : IMessageContext
	{
		Task<ISubscription> SubscribeAsync<T>(Func<T, TMessageContext, Task> subscribeMethod, Action<ISubscriptionConfigurationBuilder> configuration = null);

		Task PublishAsync<T>(T message = default(T), Action<IPublishConfigurationBuilder> configuration = null);

		Task<ISubscription> RespondAsync<TRequest, TResponse>(Func<TRequest, TMessageContext, Task<TResponse>> onMessage, Action<IResponderConfigurationBuilder> configuration = null);

		Task<TResponse> RequestAsync<TRequest, TResponse>(TRequest message = default(TRequest), Action<IRequestConfigurationBuilder> configuration = null);
	}
}