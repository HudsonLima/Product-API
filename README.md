## Projects Name
Product API

## Description
A ASP.NET Core 2.1 Web Api project with DDD. The Product API supports the management of products and it`s brands


[![Deploy to Azure](http://azuredeploy.net/deploybutton.png)](https://azuredeploy.net/)


See the Brands examples here: 

## URL

``` https://localhost:5001/index.html ```

![Product-API](./screenshots/url.PNG)

## GET all Brands

``` https://localhost:5001/api/brands/ ```

![Product-API](./screenshots/get.PNG)

## GET single Brands

``` https://localhost:5001/api/brands/1 ```

![Product-API](./screenshots/getSingle.PNG)

## GET Count Brands

``` https://localhost:5001/api/brands/count ```

![Product-API](./screenshots/getCount.PNG)

## POST a Brands

``` http://localhost:5001/api/brands/ ```

```javascript
  {
      "name": "NewBrand",
  }
```

![Product-API](./screenshots/post.PNG)

## PUT a Brand

``` http://localhost:5001/api/brands/1 ```

``` javascript
{
    "name": "NewBrand1",
    "id" : 7
}
```

![Product-API](./screenshots/put.PNG)


## DELETE a Brand

``` http://localhost:5001/api/brands/7 ```

![Product-API](./screenshots/delete.PNG)
