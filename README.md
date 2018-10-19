## Projects Name
Product API

## Description
A ASP.NET Core 2.1 Web Api project with DDD. The Product API supports the management of products and it`s brands

See the examples here: 

## Versions

``` https://localhost:5001/ ```

![ASPNETCOREWebAPIVersions](./.github/versions.jpg)

## GET all Brands

``` https://localhost:5001/api/brands ```

![ASPNETCOREWebAPIGET](./.github/get.jpg)

## GET single Brands

``` https://localhost:5001/api/brands/1 ```

![ASPNETCOREWebAPIGET](./.github/getSingle.jpg)

## GET single Brands

``` https://localhost:5001/api/brands/count ```

![ASPNETCOREWebAPIGET](./.github/getCount.jpg)

## POST a Brands

``` http://localhost:5001/api/brands/ ```

```javascript
  {
      "name": "Brand",
  }
```

![ASPNETCOREWebAPIGET](./.github/post.jpg)

## PUT a Brand

``` http://localhost:5001/api/brands/1 ```

``` javascript
{
    "name": "Brand",
    "id" : 1
}
```

![ASPNETCOREWebAPIGET](./.github/put.jpg)


## DELETE a Brand

``` http://localhost:5001/api/brands/1 ```

![ASPNETCOREWebAPIGET](./.github/delete.jpg)
