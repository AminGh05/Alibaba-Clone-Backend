﻿namespace AlibabaClone.Application.Result
{
	public class Result<T>
	{
		public ResultStatus Status { get; set; }
		public string? ErrorMessage { get; set; }
		public T? Data { get; set; }
		public bool IsSuccess => Status == ResultStatus.Success;

		public static Result<T> Success(T data)
		{
			return new Result<T>
			{
				Status = ResultStatus.Success,
				Data = data
			};
		}

		public static Result<T> Error(T data, string errorMessage)
		{
			return new Result<T>
			{
				Status = ResultStatus.Error,
				Data = data,
				ErrorMessage = errorMessage
			};
		}

		public static Result<T> NotFound(T data)
		{
			return new Result<T>
			{
				Status = ResultStatus.NotFound,
				Data = data
			};
		}
	}
}
