namespace SkiApp.Services.Internal
{
    public struct Either<TLeft, TRight> where TLeft : class where TRight : class
    {
        private readonly TLeft? _left;
        private readonly TRight? _right;
        private readonly bool _isLeft;

        public static Either<TLeft, TRight> Left(TLeft left) => new(left, null);

        public static Either<TLeft, TRight> Right(TRight right) => new(null, right);

        private Either(TLeft? left, TRight? right)
        {
            this._left = left;
            this._right = right;
            this._isLeft = left != null;
        }

        public void Match(Action<TLeft> left, Action<TRight> right)
        {
            _ = this.Match<IgnoreResult?>(
                (l) =>
                {
                    left.Invoke(l);
                    return null;
                },
                (r) =>
                {
                    right.Invoke(r);
                    return null;
                });
        }

        public TResult Match<TResult>(Func<TLeft, TResult> left, Func<TRight, TResult> right)
        {
            if (this._isLeft)
            {
                return left(this._left!);
            }
            else
            {
                return right(this._right!);
            }
        }

        private sealed class IgnoreResult { }
    }
}
