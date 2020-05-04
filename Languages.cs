namespace QuickType
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class Languages
    {
        [JsonProperty("languageParameters")]
        public LanguageParameters LanguageParameters { get; set; }

        [JsonProperty("navigation")]
        public Navigation Navigation { get; set; }

        [JsonProperty("common")]
        public Common Common { get; set; }

        [JsonProperty("facultative")]
        public LanguagesFacultative Facultative { get; set; }

        [JsonProperty("admin")]
        public LanguagesAdmin Admin { get; set; }

        [JsonProperty("agGrid")]
        public AgGrid AgGrid { get; set; }
    }

    public partial class LanguagesAdmin
    {
        [JsonProperty("uwEmployeeList")]
        public UwEmployeeList UwEmployeeList { get; set; }

        [JsonProperty("uwEmployee")]
        public UwEmployee UwEmployee { get; set; }

        [JsonProperty("UWSeriesList")]
        public UwSeriesList UwSeriesList { get; set; }

        [JsonProperty("uwSeries")]
        public AdminUwSeries UwSeries { get; set; }
    }

    public partial class UwEmployee
    {
        [JsonProperty("breadcrumb")]
        public string Breadcrumb { get; set; }

        [JsonProperty("parentBreadcrumb")]
        public string ParentBreadcrumb { get; set; }

        [JsonProperty("main")]
        public Main Main { get; set; }

        [JsonProperty("languages")]
        public LanguagesClass Languages { get; set; }

        [JsonProperty("companies")]
        public Companies Companies { get; set; }

        [JsonProperty("seriesList")]
        public SeriesList SeriesList { get; set; }

        [JsonProperty("uwSeries")]
        public UwEmployeeUwSeries UwSeries { get; set; }
    }

    public partial class Companies
    {
        [JsonProperty("allCompanyControl")]
        public string AllCompanyControl { get; set; }

        [JsonProperty("dragAndDropControl")]
        public string DragAndDropControl { get; set; }

        [JsonProperty("companyControl")]
        public string CompanyControl { get; set; }
    }

    public partial class LanguagesClass
    {
        [JsonProperty("allLanaugeControl")]
        public string AllLanaugeControl { get; set; }

        [JsonProperty("dragAndDropControl")]
        public string DragAndDropControl { get; set; }

        [JsonProperty("languagesControl")]
        public string LanguagesControl { get; set; }
    }

    public partial class Main
    {
        [JsonProperty("dailyCaseLabel")]
        public string DailyCaseLabel { get; set; }

        [JsonProperty("maxCaseCountLabel")]
        public string MaxCaseCountLabel { get; set; }

        [JsonProperty("lastTaskAssignmentDateLabel")]
        public string LastTaskAssignmentDateLabel { get; set; }

        [JsonProperty("moveCaseLabel")]
        public string MoveCaseLabel { get; set; }

        [JsonProperty("moveAddlPapersLabel")]
        public string MoveAddlPapersLabel { get; set; }

        [JsonProperty("saveButtonLabel")]
        public string SaveButtonLabel { get; set; }

        [JsonProperty("summaryHeader")]
        public string SummaryHeader { get; set; }

        [JsonProperty("detailMessage")]
        public string DetailMessage { get; set; }
    }

    public partial class SeriesList
    {
        [JsonProperty("grid")]
        public UwSeriesListGrid Grid { get; set; }

        [JsonProperty("dialog")]
        public SeriesListDialog Dialog { get; set; }

        [JsonProperty("saveMessageSummary")]
        public string SaveMessageSummary { get; set; }

        [JsonProperty("saveMessageDetail")]
        public string SaveMessageDetail { get; set; }
    }

    public partial class SeriesListDialog
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("nameLabel")]
        public string NameLabel { get; set; }

        [JsonProperty("nameErrorMessage")]
        public string NameErrorMessage { get; set; }

        [JsonProperty("seriesErrorMessage")]
        public string SeriesErrorMessage { get; set; }

        [JsonProperty("seriesLabel")]
        public string SeriesLabel { get; set; }

        [JsonProperty("seriesSequenceErrorMessage")]
        public string SeriesSequenceErrorMessage { get; set; }

        [JsonProperty("sortOrderLabel")]
        public string SortOrderLabel { get; set; }

        [JsonProperty("sortOrderErrorMessage")]
        public string SortOrderErrorMessage { get; set; }

        [JsonProperty("saveButtonText")]
        public string SaveButtonText { get; set; }

        [JsonProperty("cancelButtonText")]
        public string CancelButtonText { get; set; }

        [JsonProperty("saveMessageSummary", NullValueHandling = NullValueHandling.Ignore)]
        public string SaveMessageSummary { get; set; }

        [JsonProperty("saveMessageDetail", NullValueHandling = NullValueHandling.Ignore)]
        public string SaveMessageDetail { get; set; }
    }

    public partial class UwSeriesListGrid
    {
        [JsonProperty("nameHeader")]
        public string NameHeader { get; set; }

        [JsonProperty("sequenceHeader")]
        public string SequenceHeader { get; set; }

        [JsonProperty("sortOrderHeader")]
        public string SortOrderHeader { get; set; }
    }

    public partial class UwEmployeeUwSeries
    {
        [JsonProperty("breadcrumb")]
        public string Breadcrumb { get; set; }

        [JsonProperty("parentBreadcrumb")]
        public string ParentBreadcrumb { get; set; }

        [JsonProperty("grid")]
        public UwSeriesListGrid Grid { get; set; }

        [JsonProperty("dialog")]
        public SeriesListDialog Dialog { get; set; }
    }

    public partial class UwEmployeeList
    {
        [JsonProperty("breadcrumb")]
        public string Breadcrumb { get; set; }

        [JsonProperty("grid")]
        public UwEmployeeListGrid Grid { get; set; }
    }

    public partial class UwEmployeeListGrid
    {
        [JsonProperty("firstNameHeader")]
        public string FirstNameHeader { get; set; }

        [JsonProperty("lastNameHeader")]
        public string LastNameHeader { get; set; }

        [JsonProperty("dailyCasesHeader")]
        public string DailyCasesHeader { get; set; }

        [JsonProperty("maxCaseHeader")]
        public string MaxCaseHeader { get; set; }

        [JsonProperty("lastAssignmentHeader")]
        public string LastAssignmentHeader { get; set; }
    }

    public partial class AdminUwSeries
    {
        [JsonProperty("breadcrumb")]
        public string Breadcrumb { get; set; }

        [JsonProperty("parentBreadcrumb")]
        public string ParentBreadcrumb { get; set; }
    }

    public partial class UwSeriesList
    {
        [JsonProperty("breadcrumb")]
        public string Breadcrumb { get; set; }

        [JsonProperty("parentBreadcrumb")]
        public string ParentBreadcrumb { get; set; }

        [JsonProperty("grid")]
        public UwSeriesListGrid Grid { get; set; }

        [JsonProperty("dialog")]
        public UwSeriesListDialog Dialog { get; set; }
    }

    public partial class UwSeriesListDialog
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("nameLabel")]
        public string NameLabel { get; set; }

        [JsonProperty("nameRequireErrorMessage")]
        public string NameRequireErrorMessage { get; set; }

        [JsonProperty("seriesErrorRequireMessage")]
        public string SeriesErrorRequireMessage { get; set; }

        [JsonProperty("seriesSequenceLabel")]
        public string SeriesSequenceLabel { get; set; }

        [JsonProperty("seriesSequenceRequiredError")]
        public string SeriesSequenceRequiredError { get; set; }

        [JsonProperty("seriesSortLabel")]
        public string SeriesSortLabel { get; set; }

        [JsonProperty("seriesSortRequiredError")]
        public string SeriesSortRequiredError { get; set; }

        [JsonProperty("saveButtonText")]
        public string SaveButtonText { get; set; }

        [JsonProperty("cancelButtonText")]
        public string CancelButtonText { get; set; }

        [JsonProperty("saveMessageSummary")]
        public string SaveMessageSummary { get; set; }

        [JsonProperty("saveMessageDetail")]
        public string SaveMessageDetail { get; set; }
    }

    public partial class AgGrid
    {
        [JsonProperty("page")]
        public string Page { get; set; }

        [JsonProperty("loadingOoo")]
        public string LoadingOoo { get; set; }

        [JsonProperty("to")]
        public string To { get; set; }

        [JsonProperty("from")]
        public string From { get; set; }

        [JsonProperty("of")]
        public string Of { get; set; }
    }

    public partial class Common
    {
        [JsonProperty("documentList")]
        public DocumentList DocumentList { get; set; }
    }

    public partial class DocumentList
    {
        [JsonProperty("grid")]
        public DocumentListGrid Grid { get; set; }

        [JsonProperty("dialog")]
        public DocumentListDialog Dialog { get; set; }
    }

    public partial class DocumentListDialog
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("nameLabel")]
        public string NameLabel { get; set; }

        [JsonProperty("categoryLabel")]
        public string CategoryLabel { get; set; }

        [JsonProperty("categoryDropDownLabel")]
        public string CategoryDropDownLabel { get; set; }

        [JsonProperty("fileUploadLabel")]
        public string FileUploadLabel { get; set; }

        [JsonProperty("fileUploadButtonText")]
        public string FileUploadButtonText { get; set; }

        [JsonProperty("recievedDateLabel")]
        public string RecievedDateLabel { get; set; }

        [JsonProperty("descriptionLabel")]
        public string DescriptionLabel { get; set; }

        [JsonProperty("saveButtonLabel")]
        public string SaveButtonLabel { get; set; }

        [JsonProperty("cancelButtonLabel")]
        public string CancelButtonLabel { get; set; }

        [JsonProperty("warningMessage")]
        public WarningMessage WarningMessage { get; set; }
    }

    public partial class WarningMessage
    {
        [JsonProperty("header")]
        public string Header { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("acceptLabel")]
        public string AcceptLabel { get; set; }

        [JsonProperty("rejectLabel")]
        public string RejectLabel { get; set; }
    }

    public partial class DocumentListGrid
    {
        [JsonProperty("dateHeader")]
        public string DateHeader { get; set; }

        [JsonProperty("createdByHeader")]
        public string CreatedByHeader { get; set; }

        [JsonProperty("categoryHeader")]
        public string CategoryHeader { get; set; }

        [JsonProperty("nameHeader")]
        public string NameHeader { get; set; }
    }

    public partial class LanguagesFacultative
    {
        [JsonProperty("underwriterTasks")]
        public UnderwriterTasks UnderwriterTasks { get; set; }
    }

    public partial class UnderwriterTasks
    {
        [JsonProperty("breadcrumb")]
        public string Breadcrumb { get; set; }
    }

    public partial class LanguageParameters
    {
        [JsonProperty("calendar")]
        public Calendar Calendar { get; set; }

        [JsonProperty("currencyFormat")]
        public string CurrencyFormat { get; set; }

        [JsonProperty("dateFormatCalendar")]
        public string DateFormatCalendar { get; set; }

        [JsonProperty("dateFormatGrid")]
        public string DateFormatGrid { get; set; }

        [JsonProperty("countryCode")]
        public string CountryCode { get; set; }
    }

    public partial class Calendar
    {
        [JsonProperty("dayNames")]
        public string[] DayNames { get; set; }

        [JsonProperty("dayNamesShort")]
        public string[] DayNamesShort { get; set; }

        [JsonProperty("dayNamesMin")]
        public string[] DayNamesMin { get; set; }

        [JsonProperty("monthNames")]
        public string[] MonthNames { get; set; }

        [JsonProperty("monthNamesShort")]
        public string[] MonthNamesShort { get; set; }

        [JsonProperty("today")]
        public string Today { get; set; }

        [JsonProperty("clear")]
        public string Clear { get; set; }
    }

    public partial class Navigation
    {
        [JsonProperty("mainMenu")]
        public MainMenu MainMenu { get; set; }
    }

    public partial class MainMenu
    {
        [JsonProperty("applicationTitle")]
        public string ApplicationTitle { get; set; }

        [JsonProperty("language")]
        public About Language { get; set; }

        [JsonProperty("facultative")]
        public MainMenuFacultative Facultative { get; set; }

        [JsonProperty("admin")]
        public MainMenuAdmin Admin { get; set; }

        [JsonProperty("about")]
        public About About { get; set; }
    }

    public partial class About
    {
        [JsonProperty("menuTitle")]
        public string MenuTitle { get; set; }
    }

    public partial class MainMenuAdmin
    {
        [JsonProperty("menuTitle")]
        public string MenuTitle { get; set; }

        [JsonProperty("appGroupItem")]
        public string AppGroupItem { get; set; }

        [JsonProperty("calcParametersItem")]
        public string CalcParametersItem { get; set; }

        [JsonProperty("clientRatingItem")]
        public string ClientRatingItem { get; set; }

        [JsonProperty("codedValuesItem")]
        public string CodedValuesItem { get; set; }

        [JsonProperty("priortizationItem")]
        public string PriortizationItem { get; set; }

        [JsonProperty("secureSiteItem")]
        public string SecureSiteItem { get; set; }

        [JsonProperty("uwImpairmentsItem")]
        public string UwImpairmentsItem { get; set; }

        [JsonProperty("uwSeriesItem")]
        public string UwSeriesItem { get; set; }

        [JsonProperty("uwEmployeeItem")]
        public string UwEmployeeItem { get; set; }
    }

    public partial class MainMenuFacultative
    {
        [JsonProperty("menuTitle")]
        public string MenuTitle { get; set; }

        [JsonProperty("searchItem")]
        public string SearchItem { get; set; }

        [JsonProperty("usTasks")]
        public string UsTasks { get; set; }
    }
}