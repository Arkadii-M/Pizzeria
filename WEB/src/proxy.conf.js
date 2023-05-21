const PROXY_CONFIG = [
  {
    context: [
      "/weatherforecast",
      "/api/Account",
    ],
    target: "https://localhost:62136",
    secure: false
  }
]

module.exports = PROXY_CONFIG;
