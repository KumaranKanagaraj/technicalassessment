"use strict";

var path = require("path");
var WebpackNotifierPlugin = require("webpack-notifier");
var BrowserSyncPlugin = require("browser-sync-webpack-plugin");

module.exports = {
entry: './Scripts/src/asset/app.js',
output: {
path: path.resolve(__dirname, "./Scripts/dist/react/asset"),
filename: "bundle.js"
},
module: {
rules: [
{
test: /\.js$/,
exclude: /node_modules/,
use: {
loader: "babel-loader"
}
}
]
},
devtool: "inline-source-map",
plugins: [new WebpackNotifierPlugin(), new BrowserSyncPlugin()]
};
