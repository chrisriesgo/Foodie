Foodie: a Sample Xamarin.Forms App
==================================

Exercises:

1. (Do this first) In the iOS and Android apps, register an implementation of IRestaurantService. Hint: we're doing something similar from LocationService already. Background: http://developer.xamarin.com/guides/cross-platform/xamarin-forms/dependency-service/.
2. ListPage and FilterPage want to know when filter options have changed, but RestaurantServiceStub isn't sending a message. Update RestaurantServiceStub to send the expected message. Background: http://developer.xamarin.com/guides/cross-platform/xamarin-forms/messaging-center/.
3. PlaceCell uses databinding to display the restaurant's image and name. Add another bound control that shows the distance to the restaurant. 
4. Add a TabbedPage to display ListPage and FavoritesPage. Hint: you can add the TabbedPage to app.cs. Icons nearby.png and fav.png are included already. 
5. FilterPage includes filters for food style and maximum price. Add another filter option for minimum rating.
6. Improve the layout of FilterPage.
7. Update FilterPage to use databinding where possible.

Bugs to Fix:

1. When displaying the WebsitePage, iOS shows a ToolBarItem to "favorite" the restaurant. Android continues showing the filter ToolBarItem, which is wrong. Can you fix this? 
