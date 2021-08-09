```python
import re
import pandas as pd

# assuming all records are stored in a pandas DataFrame df
# unique customer names
customer_names = ["Lumiere Technologies", "Mendes Metal SA", "Klapisch Aerospace gmbh Munich"]
# regular expression patterns of customer names 
regexp = [".*Lumiere.*Tech.*", ".*Mendes.*Metal.*", ".*Klapisch.*Aero.*gmbh.*"]
# dataframe column names
column_names = df.columns.values

new_names = {}
# identify each names and store correspondent unique name to it
for i in range(len(column_names)):
    for j in range(len(regexp)):
        if re.search(regexp[j], column_names[i]):
            new_names[column_names[i]] = customer_names[j]
# format all column names
df = df.rename(new_names, axis=1)
# merge columns
df = df.groupby(df.columns, axis = 1).apply(lambda col: col.values)
```
My approach is to use regular expression to replace all duplicate entries with same name. Then group all entries with same name.

Assumptions:
1. all records are stored in one dataframe with customer names as column names.
2. Each customer has a unique name to refer to, and there's a list of those names obtainable.

a | a1 | a2 | b1 | b2          
-- | -- | -- | -- | --  
1 | 2 | 3 | 1 | 1
2 | 3 | 4 | 2 | 2

after uniforming customer names:

a | a | a | b | b          
-- | -- | -- | -- | --  
1 | 2 | 3 | 1 | 1
2 | 3 | 4 | 2 | 2

after merge:

a | b          
-- | --  
[1,2,3] | [1,1]
[2,3,4] | [2,2]

After `elif company == 'leibnizgmbh':`, add another `elif` condition:
```python
elif company == 'benthamplc':
        price_group =  db.query('benthamplc', customer_id)['price_group']
        raw = requests.get('https://mockend.com/prmsolutions/custom-pricing-challenge/Bentham ',
                            params={'client_pricing_segment_eq' : price_group, 
                                    'product_code_eq' : product_id}).json()
        return raw[0]['product_price']
```


