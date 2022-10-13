const { createProxyMiddleware } = require('http-proxy-middleware');

const context = [
    "/Users",
    "/Trainings",
    "/AllTrainingsByUser",
];

module.exports = function (app) {
    const appProxy = createProxyMiddleware(context, {
        target: 'https://localhost:7191',
        secure: false
    });

    app.use(appProxy);
};
