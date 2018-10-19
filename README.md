## Projects Name
Product API

## Description
A ASP.NET Core 2.1 Web Api project with DDD. The Product API supports the management of products and it`s brands

See the Brands examples here: 

## Versions

``` https://localhost:5001/ ```

![Product-API](./screenshots/url.png)

## GET all Brands

``` https://localhost:5001/api/brands/ ```

![Product-API](./screenshots/get.png)

## GET single Brands

``` https://localhost:5001/api/brands/1 ```

![Product-API](./.screenshots/getSingle.png)

## GET Count Brands

``` https://localhost:5001/api/brands/count ```

![Product-API](./screenshots/getCount.png)

## POST a Brands

``` http://localhost:5001/api/brands/ ```

```javascript
  {
      "name": "Brand",
  }
```

![Product-API](./screenshots/post.jpg)

## PUT a Brand

``` http://localhost:5001/api/brands/1 ```

``` javascript
{
    "name": "Brand",
    "id" : 1
}
```

![Product-API](./screenshots/put.jpg)


## DELETE a Brand

``` http://localhost:5001/api/brands/1 ```

![Product-API](./screenshots/delete.jpg)
