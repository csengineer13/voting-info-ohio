var gulp        = require('gulp');              // Gulp ;)
var clean       = require('gulp-clean');        // Clean out our output folders 
var concat      = require('gulp-concat');      	// Combine external dependencies
var uglify		= require('gulp-uglify');		// Minimize JS files
var rename		= require('gulp-rename');		// Rename files
var filesize	= require('gulp-filesize');		// Print filesize to console
var changed		= require('gulp-changed');		// Only files that have changed...

// SASS
var sass 		= require('gulp-sass');


// Clean output directories
gulp.task('clean', function() {
    return gulp.src('build', { read: false })
        .pipe(clean());
});


// Concat external dependencies, and minimize
gulp.task('scripts', function(){
	return gulp.src('vendor/*.js')
		.pipe(concat('vendor.js'))			// concat
		.pipe(gulp.dest('build'))			// output concat'd
		.pipe(filesize())					// print concat'd filesize
		.pipe(uglify())						// minimize
		.pipe(rename('vendor.min.js'))		// rename min'd file
		.pipe(gulp.dest('build'))			// output min'd
		.pipe(filesize())					// print min'd filesize
		.on('error', gutil.log);			// if error, log
});

gulp.task('styles', function(){
	return gulp.src('Content/sass/**/*.scss')
		.pipe(sass().on('error', sass.logError))
		.pipe(gulp.dest('Content/css/'));
});

gulp.task('watch-styles', function(){
	gulp.watch('Content/sass/**/*.scss', ['styles']);
});