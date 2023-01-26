# decision_tree.py
# ---------
# Licensing Information:  You are free to use or extend these projects for
# personal and educational purposes provided that (1) you do not distribute
# or publish solutions, (2) you retain this notice, and (3) you provide clear
# attribution to UT Dallas, including a link to http://cs.utdallas.edu.
#
# This file is part of Homework for CS6375: Machine Learning.
# Gautam Kunapuli (gautam.kunapuli@utdallas.edu)
# Sriraam Natarajan (sriraam.natarajan@utdallas.edu),
# Anjum Chida (anjum.chida@utdallas.edu)

import numpy as np
import os
import graphviz
# Resolve system path error for me , bue may should be removed if doing the auto-grade
# os.environ["PATH"] += os.pathsep + 'C:/Program  iles/Graphviz/bin/'

def partition(x):
    # partition x to v1 ... vk such that v1 is the (x == v1) ... vk is the (x == vk)
    dict = {}

    for i in range(len(x)):

        if (dict.get(x[i]) == None):   # for x[i] is not the key in the dictionary
            dict.update({x[i]: [i]})
        else:
            dict.get(x[i]).append(i)

    return dict

def entropy(y):

    # formed H(z) = p(z=v1)log2(p(z=v1)) + ... + p(z=vk)log2(p(z=vk)

    dict = partition(y)
    entropy = 0

    for k in dict.keys():
        p = len(dict.get(k)) / len(y)
        entropy += -p * np.log2(p)

    return entropy

def mutual_information(x, y):

    # Returns  I(x, y) = H(y) - H(y | x)

    dict = partition(x)
    mut_info = entropy(y)

    for i in dict.keys():
        temp = []
        for j in dict[i]:      # supposed to be dictionary index, otherwise occurs int flaw.
            temp.append(y[j])
        mut_info -= (len(temp) / len(y)) * entropy(temp)

    return mut_info

def id3(x, y, attribute_value_pairs=None, depth=0, max_depth=5):

    if attribute_value_pairs == None:  # generate attribute_value_pairs such that xi == value
        attribute_value_pairs = []
        for i in range(len(x)):
            for j in range(len(x[0])):
                if (j, x[i][j]) not in attribute_value_pairs:
                    attribute_value_pairs.append((j, x[i][j]))

    # recursively call the function
    return recursive(x, y, attribute_value_pairs, max_depth - depth)

def recursive(x, y, att_val_pair, depth):

    attribute_index = 0
    attribute_value = 0
    mutual_info = 0
    dict_a = []
    dict_b = []

    if len(y) == 0:

        return None

    if len(att_val_pair) == 0:     # Termination conditions 2&3
        return most_common_value(y)

    if depth == 0:
        return most_common_value(y)

    if isPure(y):  # Termination conditions 1
        return y[0]

    for (i, j) in att_val_pair:    # select the best pair

        tmp = mutual_information(np.array(x[:, i]).tolist(), y)  # resolve can not partition problem

        if (tmp > mutual_info):

            attribute_index = i
            attribute_value = j
            mutual_info = tmp

    for (i, j) in att_val_pair:  # remove vi == value for false branch

        if (i != attribute_index):
            dict_a.append((i, j))
            dict_b.append((i, j))
        else:
            if (j != attribute_value):
                dict_a.append((i, j))

    x1, y1, x2, y2 = splitData(x, y, attribute_index, attribute_value)  #splitting criterion for the next recursive call

    dict = {(attribute_index, attribute_value, False): recursive(x1, y1, dict_a, depth - 1),
            (attribute_index, attribute_value, True): recursive(x2, y2, dict_b, depth - 1)}

    return dict

def most_common_value(y):

    # return the value for leaf node

    if (len(y) == 0):
        return None

    dict = partition(y)
    max = 0
    most_common_value = 0

    for i in dict.keys():
        if (max < len(dict[i])):
            max = len(dict[i])
            most_common_value = i

    return most_common_value

def isPure(y):

    if len(y) == 0:
        return True

    for i in y:      # y is only 0 or 1
        if i != y[0]:
            return False

    return True

def splitData(x, y, index, value):

    x1, y1, x2, y2 = [], [], [], []

    for i in range(len(y)):

        if (x[i][index] != value):       # False branch
            x1.append(x[i])
            y1.append(y[i])
        else:                    # True branch
            x2.append(x[i])
            y2.append(y[i])

    return np.array(x1), np.array(y1), np.array(x2), np.array(y2)

def predict_example(x, tree):

    # Predicts label by recursively descending the tree until leaf node
    # return the label

    if type(tree) != dict:
        return tree

    for k in tree.keys():

        index = k[0]
        value = k[1]
        flag = k[2]

        if x[index] == value and flag == True:
            desc_level = predict_example(x, tree.get(k))
        if x[index] != value and flag == False:
            desc_level  = predict_example(x, tree.get(k))

    return desc_level

def compute_error(y_true, y_pred):

    # error = (1 / n) * sum(y_true != y_pred)

    sum = 0
    for i in range(len(y_true)):

        if (y_true[i] != y_pred[i]):
            sum += 1

    return sum/ len(y_true)

def pretty_print(tree, depth=0):

    if depth == 0:
        print('TREE')

    for index, split_criterion in enumerate(tree):
        sub_trees = tree[split_criterion]

        # Print the current node: split criterion
        print('|\t' * depth, end='')
        print('+-- [SPLIT: x{0} = {1} {2}]'.format(split_criterion[0], split_criterion[1], split_criterion[2]))

        # Print the children
        if type(sub_trees) is dict:
            pretty_print(sub_trees, depth + 1)
        else:
            print('|\t' * (depth + 1), end='')
            print('+-- [LABEL = {0}]'.format(sub_trees))

def render_dot_file(dot_string, save_file, image_format='png'):

    if type(dot_string).__name__ != 'str':
        raise TypeError('visualize() requires a string representation of a decision tree.\nUse tree.export_graphviz()'
                        'for decision trees produced by scikit-learn and to_graphviz() for decision trees produced by'
                        'your code.\n')

    # Set path to your GraphViz executable here
    os.environ["PATH"] += os.pathsep + 'C:/Program Files (x86)/Graphviz2.38/bin/'
    graph = graphviz.Source(dot_string)
    graph.format = image_format
    graph.render(save_file, view=True)

def to_graphviz(tree, dot_string='', uid=-1, depth=0):

    uid += 1       # Running index of node ids across recursion
    node_id = uid  # Node id of this node

    if depth == 0:
        dot_string += 'digraph TREE {\n'

    for split_criterion in tree:
        sub_trees = tree[split_criterion]
        attribute_index = split_criterion[0]
        attribute_value = split_criterion[1]
        split_decision = split_criterion[2]

        if not split_decision:
            # Alphabetically, False comes first
            dot_string += '    node{0} [label="x{1} = {2}?"];\n'.format(node_id, attribute_index, attribute_value)

        if type(sub_trees) is dict:
            if not split_decision:
                dot_string, right_child, uid = to_graphviz(sub_trees, dot_string=dot_string, uid=uid, depth=depth + 1)
                dot_string += '    node{0} -> node{1} [label="False"];\n'.format(node_id, right_child)
            else:
                dot_string, left_child, uid = to_graphviz(sub_trees, dot_string=dot_string, uid=uid, depth=depth + 1)
                dot_string += '    node{0} -> node{1} [label="True"];\n'.format(node_id, left_child)

        else:
            uid += 1
            dot_string += '    node{0} [label="y = {1}"];\n'.format(uid, sub_trees)
            if not split_decision:
                dot_string += '    node{0} -> node{1} [label="False"];\n'.format(node_id, uid)
            else:
                dot_string += '    node{0} -> node{1} [label="True"];\n'.format(node_id, uid)

    if depth == 0:
        dot_string += '}\n'
        return dot_string
    else:
        return dot_string, node_id, uid

if __name__ == '__main__':
    # Load the training data
    M = np.genfromtxt('./monks-1.train', missing_values=0, skip_header=0, delimiter=',', dtype=int)
    ytrn = M[:, 0]       #first column
    Xtrn = M[:, 1:]      #rest columns

    # Load the test data
    M = np.genfromtxt('./monks-1.test', missing_values=0, skip_header=0, delimiter=',', dtype=int)
    ytst = M[:, 0]
    Xtst = M[:, 1:]

    # Learn a decision tree of depth 3
    decision_tree = id3(Xtrn, ytrn, max_depth=3)

    # Pretty print it to console
    pretty_print(decision_tree)

    # Visualize the tree and save it as a PNG image
    dot_str = to_graphviz(decision_tree)
    render_dot_file(dot_str, './my_learned_tree')

    # Compute the test error
    y_pred = [predict_example(x, decision_tree) for x in Xtst]
    tst_err = compute_error(ytst, y_pred)

    print('Test Error = {0:4.2f}%.'.format(tst_err * 100))



