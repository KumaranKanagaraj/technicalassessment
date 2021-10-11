# Build

## Building Web App
1. Change the ConnectionString in `web.config` with a valid one.
1. Run the following EF migration command 

    `Enable-Migrations -ContextTypeName WebExperience.Test.Data.AssetContext`

    `add-migration InitialCreate`

    `update-database`

## Building React.js
1. Run `npm install` command to install necessary client side dependency.
1. Run `npm run dev` to convert the JSX files to js files.

## Building Console App
1. Change the ConnectionString in `app.config` with a valid one.
1. In order to run the CsvProcessingTest it's necessary to run the above migration commands (or) we can uncomment the `CreateAssetImportTable(helper)` line in CsvProcessingTest.

