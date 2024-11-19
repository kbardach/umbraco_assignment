//------------------------------------------------------------------------------
// <auto-generated>
//   This code was generated by a tool.
//
//    Umbraco.ModelsBuilder.Embedded v14.3.1+6caf53e
//
//   Changes to this file will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Linq.Expressions;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.PublishedCache;
using Umbraco.Cms.Infrastructure.ModelsBuilder;
using Umbraco.Cms.Core;
using Umbraco.Extensions;
using Umbraco.Cms.Core.Web;

namespace umbraco_assignment.Models.PublishedModels
{
	/// <summary>About Us</summary>
	[PublishedModel("aboutUs")]
	public partial class AboutUs : BaseContentModel, IMetaData, ISeo
	{
		// helpers
#pragma warning disable 0109 // new is redundant
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "14.3.1+6caf53e")]
		public new const string ModelTypeAlias = "aboutUs";
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "14.3.1+6caf53e")]
		public new const PublishedItemType ModelItemType = PublishedItemType.Content;
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "14.3.1+6caf53e")]
		[return: global::System.Diagnostics.CodeAnalysis.MaybeNull]
		public new static IPublishedContentType GetModelContentType(IPublishedSnapshotAccessor publishedSnapshotAccessor)
			=> PublishedModelUtility.GetModelContentType(publishedSnapshotAccessor, ModelItemType, ModelTypeAlias);
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "14.3.1+6caf53e")]
		[return: global::System.Diagnostics.CodeAnalysis.MaybeNull]
		public static IPublishedPropertyType GetModelPropertyType<TValue>(IPublishedSnapshotAccessor publishedSnapshotAccessor, Expression<Func<AboutUs, TValue>> selector)
			=> PublishedModelUtility.GetModelPropertyType(GetModelContentType(publishedSnapshotAccessor), selector);
#pragma warning restore 0109

		private IPublishedValueFallback _publishedValueFallback;

		// ctor
		public AboutUs(IPublishedContent content, IPublishedValueFallback publishedValueFallback)
			: base(content, publishedValueFallback)
		{
			_publishedValueFallback = publishedValueFallback;
		}

		// properties

		///<summary>
		/// Contact Button
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "14.3.1+6caf53e")]
		[global::System.Diagnostics.CodeAnalysis.MaybeNull]
		[ImplementPropertyType("contactButton")]
		public virtual string ContactButton => this.Value<string>(_publishedValueFallback, "contactButton");

		///<summary>
		/// Contact Link
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "14.3.1+6caf53e")]
		[global::System.Diagnostics.CodeAnalysis.MaybeNull]
		[ImplementPropertyType("contactLink")]
		public virtual global::System.Collections.Generic.IEnumerable<global::Umbraco.Cms.Core.Models.Link> ContactLink => this.Value<global::System.Collections.Generic.IEnumerable<global::Umbraco.Cms.Core.Models.Link>>(_publishedValueFallback, "contactLink");

		///<summary>
		/// Header Image
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "14.3.1+6caf53e")]
		[global::System.Diagnostics.CodeAnalysis.MaybeNull]
		[ImplementPropertyType("headerImage")]
		public virtual global::Umbraco.Cms.Core.Models.MediaWithCrops HeaderImage => this.Value<global::Umbraco.Cms.Core.Models.MediaWithCrops>(_publishedValueFallback, "headerImage");

		///<summary>
		/// More
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "14.3.1+6caf53e")]
		[global::System.Diagnostics.CodeAnalysis.MaybeNull]
		[ImplementPropertyType("more")]
		public virtual global::Umbraco.Cms.Core.Strings.IHtmlEncodedString More => this.Value<global::Umbraco.Cms.Core.Strings.IHtmlEncodedString>(_publishedValueFallback, "more");

		///<summary>
		/// More Header
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "14.3.1+6caf53e")]
		[global::System.Diagnostics.CodeAnalysis.MaybeNull]
		[ImplementPropertyType("moreHeader")]
		public virtual string MoreHeader => this.Value<string>(_publishedValueFallback, "moreHeader");

		///<summary>
		/// Our Story
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "14.3.1+6caf53e")]
		[global::System.Diagnostics.CodeAnalysis.MaybeNull]
		[ImplementPropertyType("ourStory")]
		public virtual global::Umbraco.Cms.Core.Strings.IHtmlEncodedString OurStory => this.Value<global::Umbraco.Cms.Core.Strings.IHtmlEncodedString>(_publishedValueFallback, "ourStory");

		///<summary>
		/// Our Story Header
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "14.3.1+6caf53e")]
		[global::System.Diagnostics.CodeAnalysis.MaybeNull]
		[ImplementPropertyType("ourStoryHeader")]
		public virtual string OurStoryHeader => this.Value<string>(_publishedValueFallback, "ourStoryHeader");

		///<summary>
		/// Our Values
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "14.3.1+6caf53e")]
		[global::System.Diagnostics.CodeAnalysis.MaybeNull]
		[ImplementPropertyType("ourValues")]
		public virtual global::Umbraco.Cms.Core.Strings.IHtmlEncodedString OurValues => this.Value<global::Umbraco.Cms.Core.Strings.IHtmlEncodedString>(_publishedValueFallback, "ourValues");

		///<summary>
		/// Slogan
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "14.3.1+6caf53e")]
		[global::System.Diagnostics.CodeAnalysis.MaybeNull]
		[ImplementPropertyType("slogan")]
		public virtual string Slogan => this.Value<string>(_publishedValueFallback, "slogan");

		///<summary>
		/// Page Header
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "14.3.1+6caf53e")]
		[global::System.Diagnostics.CodeAnalysis.MaybeNull]
		[ImplementPropertyType("title")]
		public virtual string Title => this.Value<string>(_publishedValueFallback, "title");

		///<summary>
		/// Values Header
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "14.3.1+6caf53e")]
		[global::System.Diagnostics.CodeAnalysis.MaybeNull]
		[ImplementPropertyType("valuesHeader")]
		public virtual string ValuesHeader => this.Value<string>(_publishedValueFallback, "valuesHeader");

		///<summary>
		/// MetaDescription
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "14.3.1+6caf53e")]
		[global::System.Diagnostics.CodeAnalysis.MaybeNull]
		[ImplementPropertyType("metaDescription")]
		public virtual string MetaDescription => global::umbraco_assignment.Models.PublishedModels.MetaData.GetMetaDescription(this, _publishedValueFallback);

		///<summary>
		/// MetaRobots
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "14.3.1+6caf53e")]
		[global::System.Diagnostics.CodeAnalysis.MaybeNull]
		[ImplementPropertyType("metaRobots")]
		public virtual string MetaRobots => global::umbraco_assignment.Models.PublishedModels.MetaData.GetMetaRobots(this, _publishedValueFallback);

		///<summary>
		/// Seo Title
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "14.3.1+6caf53e")]
		[global::System.Diagnostics.CodeAnalysis.MaybeNull]
		[ImplementPropertyType("seoTitle")]
		public virtual string SeoTitle => global::umbraco_assignment.Models.PublishedModels.Seo.GetSeoTitle(this, _publishedValueFallback);
	}
}
