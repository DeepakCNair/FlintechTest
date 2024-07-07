// src/setupProxy.js
const { createProxyMiddleware } = require('http-proxy-middleware');

module.exports = function (app) {
    app.use(
        '/api',
        createProxyMiddleware({
            target: 'https://localhost:7100',
            changeOrigin: true,
            secure: false, // Use this if you're working with a self-signed SSL certificate
            pathRewrite: {
                '^/api': '' // Remove '/api' from the request path
            },
            onProxyReq: (proxyReq, req, res) => {
                console.log(`Proxying request to: ${proxyReq.url}`); // Add this line
            },
            onError: (err, req, res) => {
                console.error('Proxy error:', err); // Add this line
            }
        })
    );
};