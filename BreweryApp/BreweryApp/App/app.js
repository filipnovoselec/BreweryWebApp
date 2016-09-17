var app = angular.module('app', ['ui.router', 'ngAnimate', 'ngRoute']);

app.config(function ($stateProvider, $urlRouterProvider) {
    $urlRouterProvider.otherwise('/');

    $stateProvider
        .state('home',
        {
            url: '/',
            templateUrl: '/Views/Homepage.html',
            controller: '/App/homepageController'
        })
        .state('login',
        {
            url: '/login',
            templateUrl: '/Views/Login.html',
            controller: '/App/loginController'
        })
        .state('recipe',
        {
            url: '/recipe/{id}',
            templateUrl: '/Views/Recipe.html',
            controller: '/App/recipeController'
        })
        .state('beer',
        {
            url: '/beer',
            templateUrl: '/Views/Beer.html',
            controller: '/App/beer'
        });
});

