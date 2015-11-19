# About #

To simplify unbiased voter education, make it easier to vote, and at the same time not overwhelm voters. We want to do this at the Federal, State, and Local levels. To accomplish this, we want to:

- Create personas that emulate our end users
- Create user scenarios and user contexts for our personas
- Test the derived application against these scenarios and contexts

To create a consistent user experience, we also want to employ the following design practices:

- Atomic Design
- MicroInteractions



# Research #

Some really, really basic information to provide some context/scope around what we're designing for.

## Types of Elections ##

Elections take place at the Federal, State, and Local level.

1. Primary Election
	- A "nominating" election where candidates for the General Election are chosen.
2. General Election
	- Voting for candidates that were nominated by parties (or independents) in the Primary Election.

In elections, you can also vote on:

- Proposed Legislation (referendums)
- Bond issues (borrowing of money for public projects)
- "Other Mandates"

## When Are Elections ##

- Held in even-numbered years
- U.S. Congress

_Some_ States & Local jurisdictions hold "off-year" elections (for their elected officials)

General Election: They are held on the first Tuesday after the first Monday of November.

## Requirements For Voting ##

- 18+ (mostly)




# APIs Used & Resources #

A list of where we're getting our information, and some basics on how to query/setup each API independently.

### 1. Google Civic Information API ###

Google's Civic Information API aggregates information from many sources. It has three resources it cares about: Candidates, Elections, and Divisions. It uses some under-the-hood magic to determine what it should hand us when it has conflicting sources; unless overridden, we receive what Google determines to be the "best" information for a given request.

We are using a "Client Library" to make requesting information easier, and service account so our users don't need to authenticate. We'll need to implement chaching at some point so we don't hit API Quota limits.

- [Google Dev Console](https://console.developers.google.com/project) [Uses server API Key]
- [General Info](https://developers.google.com/civic-information/)
- [Nuget Install](https://www.nuget.org/packages/Google.Apis.CivicInfo.v2/)
- [API Explorer](https://developers.google.com/apis-explorer/#p/civicinfo/v2/)

## To Do: ##

- Remove Google API references from core
- Create a VM/Model project that is shared by all
- Create batch queries to pull info based on scenarios
- Create sub-repo for the Toolkit
- Create a "how to contribute" guide