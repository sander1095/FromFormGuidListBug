# FromFormGuidListBug
Stackoverflow issue


1. Start project
2. Debug with Kestrel (NOT IIS EXPRES)
3. Get a guid from www.guidgen.com
4. Paste it twice into the `bug` endpoint in the `Ids` and twice into the `IdsAsString` field
   1. You expect 2 guid to be returned and also 2 string since you gave them as input
   2. **The actual return value is 0 guids and 1 string.**
5. Now try the `works` endpoint which uses [FromBody]
6. Do the same thing as in step 4
7. It works. 2 guids, 2 strings.


Why does `[FromForm]` and a list of strings/guids not work?
