/// <binding BeforeBuild='compile:sass, min:js' Clean='clean' ProjectOpened='default' />
"use strict";

var gulp = require('gulp'),
    rimraf = require('rimraf'),
    sass = require('gulp-sass'),
    concat = require("gulp-concat"),
    uglify = require("gulp-uglify");

var paths = {
    webroot: "./wwwroot/"
};
paths.sassPages = paths.webroot + "sass/*.scss";
paths.sass = paths.webroot + "sass/**/*.scss";
paths.js = paths.webroot + "scripts/**/*.js";
paths.concatJsDest = paths.webroot + "js/sky.min.js";
paths.concatCssDest = paths.webroot + "css";

gulp.task("clean:js", function (cb) {
    rimraf(paths.concatJsDest, cb);
});

gulp.task("clean:css", function (cb) {
    rimraf(paths.concatCssDest, cb);
});

gulp.task("clean", ["clean:js", "clean:css"]);

gulp.task('compile:sass', function () {
    gulp.src(paths.sassPages)
        .pipe(sass({ outputStyle: 'compressed' }).on('error', sass.logError))
        .pipe(gulp.dest(paths.concatCssDest));
});

gulp.task("min:js", function () {
    return gulp.src(paths.js)
        .pipe(concat(paths.concatJsDest))
        .pipe(uglify())
        .pipe(gulp.dest("."));
});

/*
    Watch all sass files even though the compile will only 
    compile the top level page which imports the other files
*/
gulp.task('watch:sass', ['compile:sass'], function () {
    gulp.watch(paths.sass, ['compile:sass']);
});
gulp.task('watch:js', ['min:js'], function () {
    gulp.watch(paths.js, ['min:js']);
});

gulp.task('default', ['watch:sass', 'watch:js']);