var theme = {
  "enabledTheme": "Pelican Theme",
  "customThemes": {
    "Pelican Theme": {
      "baseTheme": "Day",
      "stx_candle_up": {
        "color": "rgb(10 120 252)",
        "borderTopColor": "rgb(10 120 252)",
        "backgroundColor": "rgba(0, 0, 0, 0)",
        "border-left-color": "transparent"
      },
      "stx_candle_down": {
        "color": "rgb(249 73 73)",
        "borderTopColor": "rgb(249 73 73)",
        "backgroundColor": "rgba(0, 0, 0, 0)",
        "border-left-color": "transparent"
      },
      "stx_candle_shadow_up": {
        "color": "rgb(216 216 216)",
        "borderTopColor": "rgb(216 216 216)",
        "backgroundColor": "rgba(0, 0, 0, 0)",
        "border-left-color": "transparent"
      },
      "stx_candle_shadow_down": {
        "color": "rgb(216 216 216)",
        "borderTopColor": "rgb(216 216 216)",
        "backgroundColor": "rgba(0, 0, 0, 0)",
        "border-left-color": "transparent"
      },
      "stx_grid": {
        "color": "rgb(239, 239, 239)",
        "borderTopColor": "rgb(239, 239, 239)",
        "backgroundColor": "rgba(0, 0, 0, 0)",
        "border-left-color": "transparent"
      },
      "stx_grid_dark": {
        "color": "rgb(204, 204, 204)",
        "borderTopColor": "rgb(204, 204, 204)",
        "backgroundColor": "rgba(0, 0, 0, 0)",
        "border-left-color": "transparent"
      },
      "stx_xaxis_dark": {
        "color": "rgb(68, 68, 68)",
        "borderTopColor": "rgb(68, 68, 68)",
        "backgroundColor": "rgba(0, 0, 0, 0)",
        "border-left-color": "transparent"
      },
      "stx_mountain": {
        "color": "rgba(102, 202, 196, 0.00784314)",
        "borderTopColor": "rgb(102, 202, 196)",
        "backgroundColor": "rgba(102, 202, 196, 0.498039)",
        "border-left-color": "transparent"
      }
    }
  }
}
CIQ.ThemeManager.setThemes(JSON.parse(theme), chart);