//   Copyright 2011 Microsoft Corporation
//
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//
//       http://www.apache.org/licenses/LICENSE-2.0
//
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.

namespace Microsoft.Data.OData.Query.SyntacticAst
{
    using System.Collections.Generic;

    /// <summary>
    /// Equality comparer for <see cref="PathSegmentToken"/>.
    /// </summary>
    internal sealed class PathSegmentTokenEqualityComparer : EqualityComparer<PathSegmentToken>
    {
        /// <summary>
        /// Determines whether the two paths are equivalent.
        /// </summary>
        /// <param name="first">The first path to compare.</param>
        /// <param name="second">The second path to compare.</param>
        /// <returns>Whether the two paths are equivalent.</returns>
        public override bool Equals(PathSegmentToken first, PathSegmentToken second)
        {
            if (first == null && second == null)
            {
                return true;
            }

            if (first == null || second == null)
            {
                return false;
            }

            return this.ToHashableString(first) == this.ToHashableString(second);
        }

        /// <summary>
        /// Returns a hash code for the given path.
        /// </summary>
        /// <param name="path">The path to hash.</param>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode(PathSegmentToken path)
        {
            if (path == null)
            {
                return 0;
            }

            return this.ToHashableString(path).GetHashCode();
        }

        /// <summary>
        /// Converts the token to a string that is sufficiently unique to be hashed or compared.
        /// </summary>
        /// <param name="token">The path token to convert to a string.</param>
        /// <returns>A string representing the path.</returns>
        private string ToHashableString(PathSegmentToken token)
        {
            if (token.NextToken == null)
            {
                return token.Identifier;
            }

            return token.Identifier + "/" + this.ToHashableString(token.NextToken);
        }
    }
}