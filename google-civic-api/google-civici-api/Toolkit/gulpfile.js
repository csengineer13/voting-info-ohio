'use strict';

// modules
var assemble 	= require('fabricator-assemble'),
browserify 		= require('browserify'),
browserSync 	= require('browser-sync'),
concat 			= require('gulp-concat'),
csso 			= require('gulp-csso'),
del 			= require('del'),
gulp 			= require('gulp'),
gutil 			= require('gulp-util'),
gulpif 			= require('gulp-if'),
imagemin 		= require('gulp-imagemin'),
prefix 			= require('gulp-autoprefixer'),
rename 			= require('gulp-rename'),
reload 			= browserSync.reload,
runSequence 	= require('run-sequence'),
sass 			= require('gulp-sass'),
source 			= require('vinyl-source-stream'),
streamify 		= require('gulp-streamify'),
sourcemaps 		= require('gulp-sourcemaps'),
webpack 		= require('webpack'),
streamqueue 	= require('streamqueue'),
uglify 			= require('gulp-uglify'),
yml 			= require('gulp-yml');


var config = {
	dev: gutil.env.dev,
	src: {
		scripts: {
			fabricator: [
				'src/assets/fabricator/scripts/prism.js',
				'src/assets/fabricator/scripts/classList.js',
				'src/assets/fabricator/scripts/fabricator.js'
			],
			vendor: [
				'node_modules/jquery/dist/jquery.js',
				'bower_components/jquery-smooth-scroll/jquery.smooth-scroll.js',
				'bower_components/drawDoughnutChart/jquery.drawDoughnutChart.js',
				'bower_components/owl.carousel/dist/owl.carousel.js'
			],
			toolkit: './src/assets/toolkit/scripts/toolkit.js'
		},
		styles: {
			fabricator: 'src/assets/fabricator/styles/fabricator.scss',
			toolkit: 'src/assets/toolkit/styles/toolkit.scss'
		},
		images: 'src/assets/toolkit/images/**/*',
		views: 'src/toolkit/views/*.html'
	},
	dest: 'dist'		
};


// webpack
//var webpackConfig = require('./webpack.config')(config);
//var webpackCompiler = webpack(webpackConfig);


// clean
gulp.task('clean', function (cb) {
	return del([config.dest], cb);
});


// styles
gulp.task('styles:fabricator', function () {
	gulp.src(config.src.styles.fabricator)
		.pipe(sourcemaps.init())
		.pipe(sass().on('error', sass.logError))
		.pipe(prefix('last 1 version'))
		.pipe(gulpif(!config.dev, csso()))
		.pipe(rename('f.css'))
		.pipe(sourcemaps.write())
		.pipe(gulp.dest(config.dest + '/assets/fabricator/styles'))
		.pipe(gulpif(config.dev, reload({stream:true})));
});

gulp.task('styles:toolkit', function () {
	gulp.src(config.src.styles.toolkit)
		.pipe(sourcemaps.init())
		.pipe(sass().on('error', sass.logError))
		.pipe(prefix('last 1 version'))
		.pipe(gulpif(!config.dev, csso()))
		.pipe(sourcemaps.write())
		.pipe(gulp.dest(config.dest + '/assets/toolkit/styles'))
		.pipe(gulpif(config.dev, reload({stream:true})));
});

gulp.task('styles', ['styles:fabricator', 'styles:toolkit']);


// scripts
// gulp.task('webpack-scripts', function (done) {
// 	webpackCompiler.run(function (error, result) {
// 		if (error) {
// 			gutil.log(gutil.colors.red(error));
// 		}
// 		result = result.toJson();
// 		if (result.errors.length) {
// 			result.errors.forEach(function (error) {
// 				gutil.log(gutil.colors.red(error));
// 			});
// 		}
// 		done();
// 	});
// });

gulp.task('scripts:fabricator', function () {
	return gulp.src(config.src.scripts.fabricator)
		.pipe(concat('f.js'))
		.pipe(gulpif(!config.dev, uglify()))
		.pipe(gulp.dest(config.dest + '/assets/fabricator/scripts'));
});

gulp.task('scripts:toolkit', function () {

	var toolkit = function () {
		return browserify(config.src.scripts.toolkit).bundle()
			.on('error', function (error) {
				gutil.log(gutil.colors.red(error));
				this.emit('end');
			})
			.pipe(source('toolkit.js'));
	};

	var vendor = function () {
		return gulp.src(config.src.scripts.vendor)
			.pipe(concat('vendor.js'));
	};

	return streamqueue({ objectMode: true }, vendor(), toolkit())
		.pipe(streamify(concat('toolkit.js')))
		.pipe(gulpif(!config.dev, streamify(uglify())))
		.pipe(gulp.dest(config.dest + '/assets/toolkit/scripts'));

});

gulp.task('scripts', ['scripts:fabricator', 'scripts:toolkit']);



// images
gulp.task('images', ['favicon'], function () {
	return gulp.src(config.src.images)
		.pipe(imagemin())
		.pipe(gulp.dest(config.dest + '/assets/toolkit/images'));
});

gulp.task('favicon', function () {
	return gulp.src('./src/favicon.ico')
		.pipe(gulp.dest(config.dest));
});


// assemble
// gulp.task('assemble', function (done) {
// 	assemble({
// 		logErrors: config.dev
// 	});
// 	done();
// });
gulp.task('assemble', function(done) {
	assemble({
		helpers: {
			markdown: require('helper-markdown'),
			is: function(value, test, options) {
				if (value === test) {
					return options.fn(this);
				} else {
					return options.inverse(this);
				}
			},
			add: function (value, addition) {
				return value + addition;
			},
			default: function (value, defaultValue) {
				return value ? value : defaultValue;
			}
		},
		logErrors: true
	});
	done();
});


// save out data as JSON
gulp.task('data', function () {
	return gulp.src('src/data/**/*')
		.pipe(yml().on('error', gutil.log))
		.pipe(gulp.dest(config.dest + '/data'));
});



// server
gulp.task('serve', function () {

	browserSync({
		server: {
			baseDir: config.dest
		},
		notify: false,
		logPrefix: 'FABRICATOR'
	});

	/**
	 * Because webpackCompiler.watch() isn't being used
	 * manually remove the changed file path from the cache
	 */
	function webpackCache(e) {
		var keys = Object.keys(webpackConfig.cache);
		var key, matchedKey;
		for (var keyIndex = 0; keyIndex < keys.length; keyIndex++) {
			key = keys[keyIndex];
			if (key.indexOf(e.path) !== -1) {
				matchedKey = key;
				break;
			}
		}
		if (matchedKey) {
			delete webpackConfig.cache[matchedKey];
		}
	}

	gulp.task('assemble:watch', ['assemble'], reload);
	gulp.watch('src/**/*.{html,md,json,yml}', ['assemble:watch']);

	gulp.task('styles:fabricator:watch', ['styles:fabricator']);
	gulp.watch('src/assets/fabricator/styles/**/*.scss', ['styles:fabricator:watch']);

	gulp.task('styles:toolkit:watch', ['styles:toolkit']);
	gulp.watch('src/assets/toolkit/styles/**/*.scss', ['styles:toolkit:watch']);

	gulp.task('scripts:watch', ['scripts'], reload);
	gulp.watch('src/assets/{fabricator,toolkit}/scripts/**/*.js', ['scripts:watch']).on('change', webpackCache);

	gulp.task('images:watch', ['images'], reload);
	gulp.watch(config.src.images, ['images:watch']);

});


// default build task
gulp.task('default', ['clean'], function () {

	// define build tasks
	var tasks = [
		'styles',
		'scripts',
		'images',
		'data',
		'assemble'
	];

	// run build
	runSequence(tasks, function () {
		if (config.dev) {
			gulp.start('serve');
		}
	});

});
