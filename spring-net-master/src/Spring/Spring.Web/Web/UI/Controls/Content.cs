#region License

/*
 * Copyright 2002-2010 the original author or authors.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

#endregion

#region Imports

using System;
using System.ComponentModel;
using System.Web.UI;

#endregion

namespace Spring.Web.UI.Controls
{
    /// <summary>
    /// Represents Content control that can be used to populate or override placeholders
    /// within the master page.
    /// </summary>
    /// <remarks>
    /// Any content defined within this control will override default content
    /// in the matching <see cref="Spring.Web.UI.Controls.ContentPlaceHolder"/> control
    /// within the master page
    /// </remarks>
    /// <author>Aleksandar Seovic</author>
	public class Content : System.Web.UI.WebControls.Content
	{}
}
