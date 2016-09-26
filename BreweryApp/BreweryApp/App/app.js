var app = angular.module('app', ['ui.router', 'ngAnimate', 'ngRoute', 'chart.js']);

app.config(function ($stateProvider, $urlRouterProvider) {
    $urlRouterProvider.otherwise('/');

    $stateProvider
        .state('home',
        {
            url: '/',
            templateUrl: 'Views/Homepage.html',
            controller: 'homepageController'
        })
        .state('login',
        {
            url: '/login',
            templateUrl: 'Views/Login.html',
            controller: 'loginController'
        })
        .state('recipe',
        {
            url: '/recipe/{name}',
            templateUrl: 'Views/Recipe.html',
            controller: 'recipeController'
        })
        .state('beer',
        {
            url: '/beer',
            templateUrl: 'Views/Beer.html',
            controller: 'beerController'
        });
});

